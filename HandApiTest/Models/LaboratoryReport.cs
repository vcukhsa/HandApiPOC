using System;
using HandApiTest.Utilities;

namespace HandApiTest.Models
{
    public class LaboratoryReport
    {
        public string LabReportHeader { get; set; } //= "LABORATORY REPORT LINE DELIMIT";
        public string ReportHeader { get; set; } //= "(*CDR_REPORT";
        public StaticSection StaticSection { get; set; }
        public OrganismSection OrganismSection { get; set; }
        public AntibioticSection AntibioticSection { get; set; }
        public TestsSection TestsSection { get; set; }
        public FeatureSection FeatureSection { get; set; }
        public NotesSection NotesSection { get; set; }
        public string ReportFooter { get; set; } //= "CDR_REPORT*)";

        public string ToCommaDelimitedString()
        {
            string cdr = LabReportHeader + "\n" +
                "\"" + ReportHeader + "\"," +
                CommaDelimitedPrinter.PrintObject(StaticSection) +
                CommaDelimitedPrinter.PrintObject(OrganismSection) +
                CommaDelimitedPrinter.PrintObject(AntibioticSection) +
                CommaDelimitedPrinter.PrintObject(TestsSection) +
                CommaDelimitedPrinter.PrintObject(FeatureSection) +
                CommaDelimitedPrinter.PrintObject(NotesSection) +
                "\"" + ReportFooter + "\"";

            return cdr;
        }

        public LaboratoryReport()
        {
            LabReportHeader = "LABORATORY REPORT LINE DELIMIT";
            ReportHeader = "(*CDR_REPORT";
            ReportFooter = "CDR_REPORT*)";
        }
    }

    public class StaticSection
    {
        public string ReportingLabCode { get; set; } // Reporting Lab Code
        public string SourceLabCode { get; set; } // Source Lab Code
        public string ReferenceLabCode { get; set; } // Reference Lab code
        public string PatientPIDNo { get; set; } // Patient PID No
        public string ReportDate { get; set; } // Laboratory Report Date
        public string Surname { get; set; } // Surname
        public string Forename { get; set; } // Forename
        public string NHSNumber { get; set; } // NHS Number
        public string DOB { get; set; } // DOB
        public string AgeYears { get; set; } // Age years
        public string AgeMonths { get; set; } // Age months
        public string Sex { get; set; } // Sex
        public string Address { get; set; } // Address
        public string Postcode { get; set; } // Postcode
        public string LocalAuthorityCode { get; set; } // Local Authority Code
        public string HealthAuthorityCode { get; set; } // Health Authority Code
        public string BacteraemiaSource { get; set; } // Bacteraemia Source
        public string AsymptomaticIndicator { get; set; } // Asymptomatic Indicator
        public string OnsetDate { get; set; } // Date of Onset
        public string HospitalAcquired { get; set; } // Hospital Acquired
        public string RequestOrganisation { get; set; } // Hospital
        public string TravelIndicator { get; set; } // Travel indicator
        public string TravelInfo { get; set; } // Travel info
        public string OutbreakIndicator { get; set; } // Outbreak indicator
        public string OutbreakInfo { get; set; } // Outbreak Info
        public string ImmunocompromisedIndicator { get; set; } // Immunocompromised indicator
        public string VaccinationStatus { get; set; } // Vaccination Status Code
        public string Occupation { get; set; } // Occupation
        public string EthnicityCode { get; set; } // Ethnicity Code
        public string GPCode { get; set; } // GP Code
        public string AlternativeAddress { get; set; }
        public string HospitalConsultantCode { get; set; } 
        public string DeathIndicator { get; set; } // Death Indicator
        public string Comments { get; set; } // Comments
        public string Speciality { get; set; } // Speciality
        public string PCT { get; set; } // PCT
        public string Ward { get; set; } // WARD
    }

    public class OrganismSection
    {
        public string OrganismHeader { get; set; } //= "(*ORGANISMS"; // Organism Header 
        public string OrganismCode { get; set; } // Organism Code
        public string OrganismFooter { get; set; } //= "ORGANISMS*)"; // Organism Footer

        public OrganismSection()
        {
            OrganismHeader = "(*ORGANISMS";
            OrganismFooter = "ORGANISMS*)";
        }
    }

    public class AntibioticSection
    {
        public string AntibioticHeader { get; set; } //= "(*ANTIBIOTICS"; // Antibiotic Header
        public string AntibioticFooter { get; set; } //= "ANTIBIOTICS*)"; // Antibiotic Footer

        public AntibioticSection()
        {
            AntibioticHeader = "(*ANTIBIOTICS";
            AntibioticFooter = "ANTIBIOTICS*)";
        }
    }

    public class TestsSection
    {
        public string TestHeader { get; set; } // (*TESTS (Test Header))
        public string SpecimenNo1 { get; set; } // TEST#11223 (Specimen No 1)
        public string SpecimenCode1 { get; set; } // SPEC05 (Specimen Code 1)
        public string TestMethodCode1 { get; set; } // SPECMETH06 (Test Method Code 1)
        public string SpecimenSourceCode1 { get; set; } // SPECSRC08 (Specimen Source Code 1)
        public string SpecimenDate1 { get; set; } // 21/05/1999 (Specimen Date 1)
        public string TestFooter { get; set; } // TESTS*) (Test Footer)

        public TestsSection()
        {
            TestHeader = "(*TESTS";
            TestFooter = "TESTS*)";
        }
    }

    public class FeatureSection
    {
        public string FeatureHeader { get; set; } // (*FEATURES         (Feature Header))
        public string FeatureCodeIACountry { get; set; } 
        public string FeatureResultIACountry { get; set; } 
        public string FeatureNotesIACountry { get; set; } 
        public string FeatureCodeIADate { get; set; } 
        public string FeatureResultIADate { get; set; } 
        public string FeatureNotesIADate { get; set; } 
        public string FeatureCodeIADep { get; set; } 
        public string FeatureResultIADep { get; set; } 
        public string FeatureNotesIADep { get; set; } 
        public string FeatureCodeIAFlight { get; set; } 
        public string FeatureResultIAFlight { get; set; } 
        public string FeatureNotesIAFlight { get; set; } 
        public string FeatureCodeIATrain { get; set; } 
        public string FeatureResultIATrain { get; set; } 
        public string FeatureNotesIATrain { get; set; } 
        public string FeatureCodeIAVessel { get; set; } 
        public string FeatureResultIAVessel { get; set; } 
        public string FeatureNotesIAVessel { get; set; } 
        public string FeatureCodeIATestType { get; set; } 
        public string FeatureResultIATestType { get; set; } 
        public string FeatureNotesIATestType { get; set; } 
        public string FeatureCodeVaccStat { get; set; } 
        public string FeatureResultVaccStat { get; set; } 
        public string FeatureNotesVaccStat { get; set; } 
        public string FeatureCodeVOC { get; set; } 
        public string FeatureResultVOC { get; set; } 
        public string FeatureNotesVOC { get; set; } 
        public string FeatureCodeVOI { get; set; } 
        public string FeatureResultVOI { get; set; } 
        public string FeatureNotesVOI { get; set; } 
        public string FeatureCodeLineage { get; set; } 
        public string FeatureResultLineage { get; set; } 
        public string FeatureNotesLineage { get; set; } 
        public string FeatureCodeSource { get; set; } 
        public string FeatureResultSource { get; set; } 
        public string FeatureNotesSource { get; set; } 
        public string FeatureCodeMobNo { get; set; } 
        public string FeatureResultMobNo { get; set; } 
        public string FeatureNotesMobNo { get; set; } 
        public string FeatureCodeP2LandLine { get; set; } 
        public string FeatureResultP2LandLine { get; set; } 
        public string FeatureNotesP2LandLine { get; set; } 
        public string FeatureCodeEmail { get; set; } 
        public string FeatureResultEmail { get; set; } 
        public string FeatureNotesEmail { get; set; } 
        public string FeatureCodeIAPssprt { get; set; } 
        public string FeatureResultIAPssprt { get; set; } 
        public string FeatureNotesIAPssprt { get; set; } 
        public string FeatureCodeIAReference { get; set; } 
        public string FeatureResultIAReference { get; set; } 
        public string FeatureNotesIAReference { get; set; } 
        public string FeatureCodeSGTF { get; set; } 
        public string FeatureResultSGTF { get; set; } 
        public string FeatureNotesSGTF { get; set; } 
        public string FeatureCodeSGENE { get; set; } 
        public string FeatureResultSGENE { get; set; } 
        public string FeatureNotesSGENE { get; set; } 
        public string FeatureCodeSDT { get; set; } 
        public string FeatureResultSDT { get; set; } 
        public string FeatureNotesSDT { get; set; } 
        public string FeatureCodeSPD { get; set; } 
        public string FeatureResultSPD { get; set; } 
        public string FeatureNotesSPD { get; set; } 
        public string FeatureCodeDSS { get; set; } 
        public string FeatureResultDSS { get; set; } 
        public string FeatureNotesDSS { get; set; }
        public string FeatureCodeDiagResDate { get; set; } 
        public string FeatureResultDiagResDate { get; set; } 
        public string FeatureNotesDiagResDate { get; set; } 
        public string FeatureCodeResDate { get; set; } 
        public string FeatureResultResDate { get; set; } 
        public string FeatureNotesResDate { get; set; } 
        public string FeatureCodeDSSFS { get; set; } 
        public string FeatureResultDSSFS { get; set; } 
        public string FeatureNotesDSSFS { get; set; } 
        public string FeatureCodeSRDTS { get; set; } 
        public string FeatureResultSRDTS { get; set; } 
        public string FeatureNotesSRDTS { get; set; } 
        public string FeatureCodeDSR { get; set; } 
        public string FeatureResultDSR { get; set; } 
        public string FeatureNotesDSR { get; set; }  
        public string FeatureFooter { get; set; } // FEATURES*)        (Feature Footer)

        public FeatureSection()
        {
            FeatureHeader = "(*FEATURES";
            FeatureFooter = "FEATURES*)";
        }
    }

    public class NotesSection
    {
        public string NotesHeader { get; set; } // (*NOTES				(Notes Header))
        public string Notes { get; set; } // Patient notes are put here		(Notes)
        // public string MoreNotes { get; set; } // More notes are put here		(Notes)
        // public string AndMoreNotes { get; set; } // And more notes are put here		(Notes)
        public string NotesFooter { get; set; } // NOTES*)				(Notes Footer)

        public NotesSection()
        {
            NotesHeader = "(*NOTES"; 
            NotesFooter = "NOTES*)"; 
        }
    }
}