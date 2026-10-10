namespace CNAB240
{
    public class Class_FileHeaderRegistration
    {
        /// <summary>
        /// Bank Code in the Clearance House (posição 1 a 3).
        /// </summary>
        /// <value>0</value>
        public string? BankCode { get; set; }

        /// <summary>
        /// Service Batch (posição 4 a 7).
        /// </summary>
        /// <value>0000</value>
        public string? ServiceBatch { get; set; }

        /// <summary>
        /// Type of Registration (posição 8 a 8).
        /// </summary>
        /// <value>0</value>
        public string? TypeOfRegistration { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 9 a 17).
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
        /// Checking Digit of the Branch/ Account (posição 72 a 72).
        /// </summary>
        public string? BranchAccountDV { get; set; }

        /// <summary>
        /// Name of the Company (posição 73 a 102).
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// Bank Name (posição 103 a 132).
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 133 a 142).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab2 { get; set; }

        /// <summary>
        /// Remittance / Return Code (posição 143 a 143).
        /// </summary>
        public string? RemittanceReturnCode { get; set; }

        /// <summary>
        /// File Generation Date (posição 144 a 151).
        /// </summary>
        public string? FileGenerationDate { get; set; }

        /// <summary>
        /// File Generation Time (posição 152 a 157).
        /// </summary>
        public string? FileGenerationTime { get; set; }

        /// <summary>
        /// File Sequential Number (posição 158 a 163).
        /// </summary>
        public string? FileSequentialNumber { get; set; }

        /// <summary>
        /// File Layout Version # (posição 164 a 166).
        /// </summary>
        /// <value>050</value>
        public string? FileLayoutVersion { get; set; }

        /// <summary>
        /// File Recording Density (posição 167 a 171).
        /// </summary>
        public string? FileRecordingDensity { get; set; }

        /// <summary>
        /// For Reserved Use by the Bank (posição 172 a 191).
        /// </summary>
        public string? ReservedBank { get; set; }

        /// <summary>
        /// For Reserved Use by the Company (posição 192 a 211).
        /// </summary>
        public string? ReservedCompany { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 212 a 240).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab3 { get; set; }
    }
}

