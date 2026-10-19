namespace CNAB240
{
    public class Class_DetailRegistrationSegE
    {
        /// <summary>
        /// Bank Code in the Clearance House (posição 1 a 3).
        /// </summary>
        public string? BankCode { get; set; }

        /// <summary>
        /// Service Batch (posição 4 a 7).
        /// </summary>
        public string? ServiceBatch { get; set; }

        /// <summary>
        /// Type of Registration (posição 8 a 8).
        /// </summary>
        /// <value>3</value>
        public string? TypeOfRegistration { get; set; }

        /// <summary>
        /// Sequential N. of the Registration in the Batch (posição 9 a 13).
        /// </summary>
        public string? SequentialRegistrationNumber { get; set; }

        /// <summary>
        /// Segment Code of the Detail Reg. (posição 14 a 14).
        /// </summary>
        /// <value>E</value>
        public string? SegmentCode { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 15 a 17).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab1 { get; set; }

        /// <summary>
        /// Type of Company Enrollment (posição 18 a 18).
        /// </summary>
        public string? CompanyEnrollmentType { get; set; }

        /// <summary>
        /// Número de Inscrição da Empresa (posição 19 a 32).
        /// </summary>
        public string? CompanyEnrollmentNumber { get; set; }

        /// <summary>
        /// Agreement Code in the Bank (posição 33 a 52).
        /// </summary>
        public string? Agreement { get; set; }

        /// <summary>
        /// Branch that Keeps the Account (posição 53 a 57).
        /// </summary>
        public string? BranchCode { get; set; }

        /// <summary>
        /// Dígito Verificador da Agência (posição 58 a 58).
        /// </summary>
        public string? BranchDV { get; set; }

        /// <summary>
        /// Checking Account Number (posição 59 a 70).
        /// </summary>
        public string? CheckingAccountNumber { get; set; }

        /// <summary>
        /// Checking Digit of the Account (posição 71 a 71).
        /// </summary>
        public string? CheckingAccountDV { get; set; }

        /// <summary>
        /// Checking Digit of Branch /Account (posição 72 a 72).
        /// </summary>
        public string? BranchAccountDV { get; set; }

        /// <summary>
        /// Name of the Company (posição 73 a 102).
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN/CNAB (posição 103 a 108).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab2 { get; set; }

        /// <summary>
        /// Type of the Entry (posição 109 a 111).
        /// </summary>
        public string? TypeOfEntry { get; set; }

        /// <summary>
        /// Type of Entry Complement (posição 112 a 113).
        /// </summary>
        public string? TypeOfEntryComplement { get; set; }

        /// <summary>
        /// Entry Complement (posição 114 a 133).
        /// </summary>
        public string? EntryComplement { get; set; }

        /// <summary>
        /// CPMF Exemption Identification (posição 134 a 134).
        /// </summary>
        public string? CpmfExemption { get; set; }

        /// <summary>
        /// Accounting Date (posição 135 a 142).
        /// </summary>
        public string? AccountingDate { get; set; }

        /// <summary>
        /// Entry Date (posição 143 a 150).
        /// </summary>
        public string? EntryDate { get; set; }

        /// <summary>
        /// Entry Value (posição 151 a 168).
        /// </summary>
        public string? EntryValue { get; set; }

        /// <summary>
        /// Entry Type: Debt/Credit Value (posição 169 a 169).
        /// </summary>
        public string? EntryType { get; set; }

        /// <summary>
        /// Entry Category (posição 170 a 172).
        /// </summary>
        public string? EntryCategory { get; set; }

        /// <summary>
        /// History Code in the Bank (posição 173 a 176).
        /// </summary>
        public string? HistoryCode { get; set; }

        /// <summary>
        /// Entry History Description in the Bank (posição 177 a 201).
        /// </summary>
        public string? HistoryDescription { get; set; }

        /// <summary>
        /// Document/Complement Number (posição 202 a 240).
        /// </summary>
        public string? DocumentNumber { get; set; }
    }
}

