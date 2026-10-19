namespace CNAB240
{
    public class Class_BatchHeaderRegistration
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
        /// <value>1</value>
        public string? TypeOfRegistration { get; set; }

        /// <summary>
        /// Type of Operation (posição 9 a 9).
        /// </summary>
        /// <value>E</value>
        public string? TypeOfOperation { get; set; }

        /// <summary>
        /// Type of Service (posição 10 a 11).
        /// </summary>
        /// <value>04</value>
        public string? TypeOfService { get; set; }

        /// <summary>
        /// Entry Form (posição 12 a 13).
        /// </summary>
        /// <value>40</value>
        public string? EntryForm { get; set; }

        /// <summary>
        /// Batch Layout Version # (posição 14 a 16).
        /// </summary>
        /// <value>050</value>
        public string? BatchLayoutVersion { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 17 a 17).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab1 { get; set; }

        /// <summary>
        /// Type of Company Enrollment (posição 18 a 18).
        /// </summary>
        public string? CompanyEnrollmentType { get; set; }

        /// <summary>
        /// Company Enrollment Number (posição 19 a 32).
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
        /// Checking Digit of the Branch (posição 58 a 58).
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
        /// Exclusive Use by FEBRABAN/CNAB (posição 103 a 142).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab2 { get; set; }

        /// <summary>
        /// Date of the Initial Balance (posição 143 a 150).
        /// </summary>
        public string? InitialBalanceDate { get; set; }

        /// <summary>
        /// Value of the Initial Balance (posição 151 a 168).
        /// </summary>
        public string? InitialBalanceValue { get; set; }

        /// <summary>
        /// Status of the Initial Balance (posição 169 a 169).
        /// </summary>
        public string? InitialBalanceStatus { get; set; }

        /// <summary>
        /// Position of the Initial Balance (posição 170 a 170).
        /// </summary>
        public string? InitialBalancePosition { get; set; }

        /// <summary>
        /// Currency Referred to in the Statement (posição 171 a 173).
        /// </summary>
        public string? InitialBalanceCurrency { get; set; }

        /// <summary>
        /// Sequence Number in the Statement (posição 174 a 178).
        /// </summary>
        public string? InitialBalanceSequence { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 179 a 240).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab3 { get; set; }
    }
}

