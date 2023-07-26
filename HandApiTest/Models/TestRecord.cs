using System;

namespace HandApiTest.Models
{
    public class TestRecord
    {
        public string SourceUID { get; set; }
        public Subject Subject { get; set; }
        public Requester Requester { get; set; }
        public LabSubmission LabSubmission { get; set; }
        public Test Test {get; set;}

        public TestRecord()
        {
            SourceUID = string.Empty;
            Subject = new Subject();
            Requester = new Requester();
            LabSubmission = new LabSubmission();
            Test = new Test();
        }
    }

    public class Subject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NHSNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Ethnicity { get; set; }
        public string VaccinationCode { get; set; }
        public string ImmunoCompromisedIndication { get; set; }
        public string Occupation { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public TravelInfo TravelInfo { get; set; }
        public string PassportNumber { get; set; }

        public Subject()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            NHSNumber = string.Empty;
            DateOfBirth = string.Empty;
            Sex = string.Empty;
            Ethnicity = string.Empty;
            VaccinationCode = string.Empty;
            ImmunoCompromisedIndication = string.Empty;
            Occupation = string.Empty;
            ContactDetails = new ContactDetails();
            TravelInfo = new TravelInfo();
            PassportNumber = string.Empty;
        }
    }

    public class ContactDetails
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public Address HomeAddress { get; set; }
        public Address CurrentAddress { get; set; }

        public ContactDetails()
        {
            Email = string.Empty;
            Mobile = string.Empty;
            Landline = string.Empty;
            HomeAddress = new Address();
            CurrentAddress = new Address();
        }
    }

    public class TravelInfo
    {
        public string DepartureDestination { get; set; }
        public string UKArrivalDate { get; set; }
        public string DepartureDateNonExemptCountry { get; set; }
        public TransportInfo TransportInfo { get; set; }

        public TravelInfo()
        {
            DepartureDestination = string.Empty;
            UKArrivalDate = string.Empty;
            DepartureDateNonExemptCountry = string.Empty;
            TransportInfo = new TransportInfo();
        }
    }

    public class TransportInfo
    {
        public string FlightNo { get; set; }
        public string TrainNo { get; set; }
        public string VesselName { get; set; }

        public TransportInfo()
        {
            FlightNo = string.Empty;
            TrainNo = string.Empty;
            VesselName = string.Empty;
        }
    }

    public class Requester
    {
        public string OrganisationName { get; set; }
        public string OrganisationType { get; set; }
        public string OrganisationRole { get; set; }
        public string OrganisationContactFirstName { get; set; }
        public string OrganisationContactLastName { get; set; }
        public Address Address { get; set; }

        public Requester()
        {
            OrganisationName = string.Empty;
            OrganisationType = string.Empty;
            OrganisationRole = string.Empty;
            OrganisationContactFirstName = string.Empty;
            OrganisationContactLastName = string.Empty;
            Address = new Address(); // assuming Address class has a default constructor
        }
    }

    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public Address()
        {
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            Town = string.Empty;
            County = string.Empty;
            Postcode = string.Empty;
            Country = string.Empty;
        }
    }

    public class LabSubmission
    {
        public TestResult TestResult { get; set; }

        public LabSubmission()
        {
            TestResult = new TestResult();
        }
    }

    public class TestResult
    {
        public string ReportingLabCode { get; set; }
        public string ReportingLabName { get; set; }
        public string SourceLabCode { get; set; }
        public string ReferenceLab { get; set; }
        public string SpecimenId { get; set; }
        public string SpecimenType { get; set; }
        public string SpecimenDateTime { get; set; }
        public string DiagnosticSpecimenReceivedDateTime { get; set; }
        public string GenomicsSpecimenReceivedDateTime { get; set; }
        public string TestResultDiagnosticReportedDateTime { get; set; }
        public string TestResultGenomicReportedDateTime { get; set; }
        public string Result { get; set; }
        public string TestProcessedDiagnosticDateTime { get; set; }
        public string TestProcessedGenomicDateTime { get; set; }
        public string SubjectInformedDateTime { get; set; }
        public string OtherTestResult { get; set; }
        public string VOC { get; set; }
        public string VUI { get; set; }
        public string PangoLineage { get; set; }
        public string SGeneTargetFailureIndicator { get; set; }
        public float SGeneCq { get; set; }
        public float NGene { get; set; }
        public float OrframeRegion { get; set; }
        public float Ms2Phage { get; set; }
        public float EnvelopeGene { get; set; }
        public string LabComments { get; set; }
        public Address Address { get; set; }

        public TestResult()
        {
            ReportingLabCode = string.Empty;
            ReportingLabName = string.Empty;
            SourceLabCode = string.Empty;
            ReferenceLab = string.Empty;
            SpecimenId = string.Empty;
            SpecimenType = string.Empty;
            SpecimenDateTime = string.Empty;
            DiagnosticSpecimenReceivedDateTime = string.Empty;
            GenomicsSpecimenReceivedDateTime = string.Empty;
            TestResultDiagnosticReportedDateTime = string.Empty;
            TestResultGenomicReportedDateTime = string.Empty;
            Result = string.Empty;
            TestProcessedDiagnosticDateTime = string.Empty;
            TestProcessedGenomicDateTime = string.Empty;
            SubjectInformedDateTime = string.Empty;
            OtherTestResult = string.Empty;
            VOC = string.Empty;
            VUI = string.Empty;
            PangoLineage = string.Empty;
            SGeneTargetFailureIndicator = string.Empty;
            LabComments = string.Empty;
            Address = new Address();
        }
    }

    public class Test
    {
        public string TestProvider { get; set; }
        public string TestMethod { get; set; }
        public string TestEquipmentManufacturer { get; set; }
        public string SampleNature { get; set; }
        public string EstablishmentNature { get; set; }
        public string TestType { get; set; }
        public bool CohortPool { get; set; }
        public string OrganismName { get; set; }
        public string TestReason { get; set; }
        public string BookingReference { get; set; }

        public Test()
        {
            TestProvider = string.Empty;
            TestMethod = string.Empty;
            TestEquipmentManufacturer = string.Empty;
            SampleNature = string.Empty;
            EstablishmentNature = string.Empty;
            TestType = string.Empty;
            OrganismName = string.Empty;
            TestReason = string.Empty;
            BookingReference = string.Empty;
        }
    }
}