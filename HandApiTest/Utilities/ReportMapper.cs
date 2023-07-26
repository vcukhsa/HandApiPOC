using System;
using System.Collections.Generic;
using HandApiTest.Models;

namespace HandApiTest.Utilities
{
    public static class ReportMapper
    {
        public static LaboratoryReport MapTestRecordToLaboratoryReport (TestRecord testRecord)
        {
            var isVocORVoiPresent = ReportMapper.isVocORVoiPresent(
                testRecord.LabSubmission.TestResult.VOC,
                testRecord.LabSubmission.TestResult.VUI
            );

            StaticSection staticSection = new()
            {
                ReportingLabCode = testRecord.LabSubmission.TestResult.ReportingLabCode,
                SourceLabCode = testRecord.LabSubmission.TestResult.SourceLabCode,
                ReferenceLabCode = testRecord.LabSubmission.TestResult.ReferenceLab,
                PatientPIDNo = "",
                ReportDate = testRecord.LabSubmission.TestResult.SubjectInformedDateTime,
                Surname = testRecord.Subject.LastName,
                Forename = testRecord.Subject.FirstName,
                NHSNumber = testRecord.Subject.NHSNumber,
                DOB = testRecord.Subject.DateOfBirth,
                AgeYears = "",
                AgeMonths = "",
                Sex = testRecord.Subject.Sex,
                Address = GetFullAddress(testRecord.Subject.ContactDetails.HomeAddress),
                Postcode = testRecord.Subject.ContactDetails.HomeAddress.Postcode,
                LocalAuthorityCode = "",
                HealthAuthorityCode = "",
                BacteraemiaSource = "",
                AsymptomaticIndicator = "",
                OnsetDate = "",
                HospitalAcquired = "",
                RequestOrganisation = "",
                TravelIndicator = "",
                TravelInfo = "",
                OutbreakIndicator = "",
                OutbreakInfo = "",
                ImmunocompromisedIndicator = testRecord.Subject.ImmunoCompromisedIndication,
                VaccinationStatus = VaccineCodeToDesc(testRecord.Subject.VaccinationCode),
                Occupation = testRecord.Subject.Occupation,
                EthnicityCode = testRecord.Subject.Ethnicity,
                GPCode = "",
                AlternativeAddress = GetFullAddress(testRecord.Subject.ContactDetails.CurrentAddress),
                HospitalConsultantCode = "",
                DeathIndicator = "",
                Comments = "",
                Speciality = "",
                PCT = "",
                Ward = "",
            };

            OrganismSection organismSection = new()
            {
                OrganismCode = MapOrganismResultToCode(
                    testRecord.Test.OrganismName,
                    testRecord.LabSubmission.TestResult.Result?.ToUpper()
                ),
            };
            
            AntibioticSection antibioticSection = new();
            
            TestsSection testsSection = new()
            {
                SpecimenNo1 = testRecord.LabSubmission.TestResult.SpecimenId,
                SpecimenCode1 = testRecord.LabSubmission.TestResult.SpecimenType,
                TestMethodCode1 = testRecord.Test.TestMethod,
                SpecimenSourceCode1 = testRecord.Requester.OrganisationType,
                SpecimenDate1 = testRecord.LabSubmission.TestResult.SpecimenDateTime,
            };
            
            FeatureSection featureSection = new()
            {
                FeatureCodeIACountry = "IA_COUNTRY",
                FeatureResultIACountry = IsEmptyStr(testRecord.Subject.TravelInfo.DepartureDestination),
                FeatureNotesIACountry = testRecord.Subject.TravelInfo.DepartureDestination,
                FeatureCodeIADate = "IA_DATE",
                FeatureResultIADate = IsEmptyStr(testRecord.Subject.TravelInfo.UKArrivalDate),
                FeatureNotesIADate = testRecord.Subject.TravelInfo.UKArrivalDate,
                FeatureCodeIADep = "IA_DEP",
                FeatureResultIADep = IsEmptyStr(testRecord.Subject.TravelInfo.DepartureDateNonExemptCountry),
                FeatureNotesIADep = testRecord.Subject.TravelInfo.DepartureDateNonExemptCountry,
                FeatureCodeIAFlight = "IA_FLIGHT",
                FeatureResultIAFlight = IsEmptyStr(testRecord.Subject.TravelInfo.TransportInfo.FlightNo),
                FeatureNotesIAFlight = testRecord.Subject.TravelInfo.TransportInfo.FlightNo,
                FeatureCodeIATrain = "IA_TRAIN",
                FeatureResultIATrain = IsEmptyStr(testRecord.Subject.TravelInfo.TransportInfo.TrainNo),
                FeatureNotesIATrain = testRecord.Subject.TravelInfo.TransportInfo.TrainNo,
                FeatureCodeIAVessel = "IA_VESSEL",
                FeatureResultIAVessel = IsEmptyStr(testRecord.Subject.TravelInfo.TransportInfo.VesselName),
                FeatureNotesIAVessel = testRecord.Subject.TravelInfo.TransportInfo.VesselName,
                FeatureCodeIATestType = "IA_TESTTYPE",
                FeatureResultIATestType = IsEmptyStr(testRecord.Test.TestReason),
                FeatureNotesIATestType = testRecord.Test.TestReason,
                FeatureCodeVaccStat = "VACCSTAT",
                FeatureResultVaccStat = IsEmptyStr(testRecord.Subject.VaccinationCode),
                FeatureNotesVaccStat = VaccineCodeToStat(testRecord.Subject.VaccinationCode),
                FeatureCodeVOC = "VOC",
                FeatureResultVOC = IsEmptyStr(testRecord.LabSubmission.TestResult.VOC),
                FeatureNotesVOC = testRecord.LabSubmission.TestResult.VOC,
                FeatureCodeVOI = "VOI",
                FeatureResultVOI = IsEmptyStr(testRecord.LabSubmission.TestResult.VUI),
                FeatureNotesVOI = testRecord.LabSubmission.TestResult.VUI,
                FeatureCodeLineage = "LINEAGE",
                FeatureResultLineage = IsEmptyStr(testRecord.LabSubmission.TestResult.PangoLineage),
                FeatureNotesLineage = testRecord.LabSubmission.TestResult.PangoLineage,
                FeatureCodeSource = "SOURCE",
                FeatureResultSource = "Y",
                FeatureNotesSource = "RTTS",    //TODO: keep this?
                FeatureCodeMobNo = "MOBNO",
                FeatureResultMobNo = IsEmptyStr(testRecord.Subject.ContactDetails.Mobile),
                FeatureNotesMobNo = testRecord.Subject.ContactDetails.Mobile,
                FeatureCodeP2LandLine = "P2Landline",
                FeatureResultP2LandLine = IsEmptyStr(testRecord.Subject.ContactDetails.Landline),
                FeatureNotesP2LandLine = testRecord.Subject.ContactDetails.Landline,
                FeatureCodeEmail = "EMAIL",
                FeatureResultEmail = IsEmptyStr(testRecord.Subject.ContactDetails.Email),
                FeatureNotesEmail = testRecord.Subject.ContactDetails.Email,
                FeatureCodeIAPssprt = "IA_PSSPRT",
                FeatureResultIAPssprt = IsEmptyStr(testRecord.Subject.PassportNumber),
                FeatureNotesIAPssprt = testRecord.Subject.PassportNumber,
                FeatureCodeIAReference = "IA_REFERENCE",
                FeatureResultIAReference = IsEmptyStr(testRecord.Test.BookingReference),
                FeatureNotesIAReference = testRecord.Test.BookingReference,
                FeatureCodeSGTF = "SGTF",
                FeatureResultSGTF = IsEmptyStr(testRecord.LabSubmission.TestResult.SGeneTargetFailureIndicator),
                FeatureNotesSGTF = testRecord.LabSubmission.TestResult.SGeneTargetFailureIndicator,
                FeatureCodeSGENE = "SGENE",
                FeatureResultSGENE = IsFloatValid(testRecord.LabSubmission.TestResult.SGeneCq),
                FeatureNotesSGENE = SGeneCqConvertor(testRecord.LabSubmission.TestResult.SGeneCq),
                FeatureCodeSDT = "SDT",
                FeatureResultSDT = IsEmptyStr(testRecord.LabSubmission.TestResult.SpecimenDateTime),
                FeatureNotesSDT = testRecord.LabSubmission.TestResult.SpecimenDateTime,
                FeatureCodeSPD = "SPD",
                FeatureResultSPD = isVocORVoiPresent ? "N" : IsEmptyStr(testRecord.LabSubmission.TestResult.TestProcessedDiagnosticDateTime),
                FeatureNotesSPD = testRecord.LabSubmission.TestResult.TestProcessedDiagnosticDateTime,
                FeatureCodeDSS = "DSS",
                FeatureResultDSS = isVocORVoiPresent ? IsEmptyStr(testRecord.LabSubmission.TestResult.TestProcessedGenomicDateTime) : "N",
                FeatureNotesDSS = testRecord.LabSubmission.TestResult.TestProcessedGenomicDateTime,
                FeatureCodeDiagResDate = "DIAGRESDATE",
                FeatureResultDiagResDate = isVocORVoiPresent ? IsEmptyStr(testRecord.LabSubmission.TestResult.TestResultDiagnosticReportedDateTime) : "N",
                FeatureNotesDiagResDate = testRecord.LabSubmission.TestResult.TestResultDiagnosticReportedDateTime,
                FeatureCodeResDate = "RESDATE",
                FeatureResultResDate = isVocORVoiPresent ? IsEmptyStr(testRecord.LabSubmission.TestResult.TestResultGenomicReportedDateTime) : "N",
                FeatureNotesResDate = testRecord.LabSubmission.TestResult.TestResultGenomicReportedDateTime,
                FeatureCodeDSSFS = "DSSFS",
                FeatureResultDSSFS = isVocORVoiPresent ? IsEmptyStr(testRecord.LabSubmission.TestResult.GenomicsSpecimenReceivedDateTime) : "N",
                FeatureNotesDSSFS = testRecord.LabSubmission.TestResult.GenomicsSpecimenReceivedDateTime,
                FeatureCodeSRDTS = "SRDTS",
                FeatureResultSRDTS = IsEmptyStr(testRecord.LabSubmission.TestResult.DiagnosticSpecimenReceivedDateTime),
                FeatureNotesSRDTS = testRecord.LabSubmission.TestResult.DiagnosticSpecimenReceivedDateTime,
                FeatureCodeDSR = "DSR",
                FeatureResultDSR = IsEmptyStr(testRecord.LabSubmission.TestResult.SubjectInformedDateTime),
                FeatureNotesDSR = testRecord.LabSubmission.TestResult.SubjectInformedDateTime,
            };
            
            NotesSection notesSection = new();

            LaboratoryReport laboratoryReport = new()
            {
                StaticSection = staticSection,
                OrganismSection = organismSection,
                AntibioticSection = antibioticSection,
                TestsSection = testsSection,
                FeatureSection = featureSection,
                NotesSection = notesSection
            };

            return laboratoryReport;
        }

        private static string GetFullAddress(Address address)
        {
            List<string> addressParts = new List<string>();

            if (!string.IsNullOrWhiteSpace(address.AddressLine1))
            {
                addressParts.Add(address.AddressLine1);
            }
            if (!string.IsNullOrWhiteSpace(address.AddressLine2))
            {
                addressParts.Add(address.AddressLine2);
            }
            if (!string.IsNullOrWhiteSpace(address.AddressLine3))
            {
                addressParts.Add(address.AddressLine3);
            }
            if (!string.IsNullOrWhiteSpace(address.Town))
            {
                addressParts.Add(address.Town);
            }
            if (!string.IsNullOrWhiteSpace(address.County))
            {
                addressParts.Add(address.County);
            }
            // skip PostCode
            if (!string.IsNullOrWhiteSpace(address.Country))
            {
                addressParts.Add(address.Country);
            }

            string fullAddress = string.Join(", ", addressParts);

            return fullAddress;
        }

        private static string MapOrganismResultToCode(string organism, string result)
        {
            switch (organism)
            {
                case "SARS-COV-2 ANTIBODY":
                    switch (result)
                    {
                        case "INDETERMINATE":
                            return "3150.0029";
                        case "VOID":
                            return "3150.0031";
                    }
                    break;
                case "SARS-CoV-2 CORONAVIRUS (Covid-19)":
                    switch (result)
                    {
                        case "POSITIVE":
                            return "3150.0020";
                        case "INDETERMINATE":
                            return "3150.0015";
                        case "NEGATIVE":
                            return "0000.0002";
                        case "VOID":
                            return "0000.0003";
                    }
                    break;
                case "SARS-COV-2 IGA ANTIBODY":
                    switch (result)
                    {
                        case "NEGATIVE":
                            return "3150.0028";
                        case "POSITIVE":
                            return "3150.0027";
                    }
                    break;
                case "SARS-COV-2 IGG ANTIBODY":
                    switch (result)
                    {
                        case "NEGATIVE":
                            return "3150.0026";
                        case "POSITIVE":
                            return "3150.0025";
                    }
                    break;
                case "SARS-COV-2 IGM ANTIBODY":
                    switch (result)
                    {
                        case "NEGATIVE":
                            return "3150.0024";
                        case "POSITIVE":
                            return "3150.0023";
                    }
                    break;
                case "SARS-COV-2 TOTAL ANTIBODY":
                    switch (result)
                    {
                        case "NEGATIVE":
                            return "3150.0022";
                        case "POSITIVE":
                            return "3150.0021";
                    }
                    break;
            }

            return string.Empty; // Return an empty string if no matching code is found
        }

        private static string IsEmptyStr(string str)
        {
            return string.IsNullOrWhiteSpace(str) ? "N" : "Y";
        }

        private static bool isVocORVoiPresent(string voc, string voi)
        {
            return !string.IsNullOrWhiteSpace(voc) || !string.IsNullOrWhiteSpace(voi);
        }

        private static string VaccineCodeToDesc(string code)
        {
            switch (code)
            {
                case "1":
                    return "COMPLETE VACCINATION";
                case "2":
                    return "INCOMPLETE VACCINATION";
                case "3":
                    return "NOT VACCINATED";
                case "9":
                    return "UNKNOWN";
            }
            return string.Empty;
        }

        private static string VaccineCodeToStat(string code)
        {
            switch (code)
            {
                case "1":
                    return "YES";
                case "2":
                case "3":
                case "9":
                    return "NO";
            }
            return string.Empty;
        }

        private static string IsFloatValid(float num)
        {
            return num <= 0.0 ? "N" : "Y";
        }

        private static string SGeneCqConvertor(float num)
        {
            return num <= 0.0? "" : num.ToString();
        }
    }
}