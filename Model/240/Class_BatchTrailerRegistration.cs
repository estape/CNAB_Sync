namespace CNAB240
{
    public class Class_BatchTrailerRegistration
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
        /// <value>5</value>
        public string? TypeOfRegistration { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN/CNAB (posição 9 a 17).
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
        /// Agência Mantenedora da Conta (posição 53 a 57).
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
        /// Exclusive Use by FEBRABAN/CNAB (posição 73 a 88).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab2 { get; set; }

        /// <summary>
        /// Connected from the previous day (posição 89 a 106).
        /// </summary>
        public string? BlockedPreviousDay { get; set; }

        /// <summary>
        /// Account Limit (posição 107 a 124).
        /// </summary>
        public string? AccountLimit { get; set; }

        /// <summary>
        /// Connected from the day (posição 125 a 142).
        /// </summary>
        public string? BlockedFromDay { get; set; }

        /// <summary>
        /// Final Balance Date (posição 143 a 150).
        /// </summary>
        public string? FinalBalanceDate { get; set; }

        /// <summary>
        /// Final Balance Value (posição 151 a 168).
        /// </summary>
        public string? FinalBalanceValue { get; set; }

        /// <summary>
        /// Final Balance Status (posição 169 a 169).
        /// </summary>
        public string? FinalBalanceStatus { get; set; }

        /// <summary>
        /// Final Balance Position (posição 170 a 170).
        /// </summary>
        public string? FinalBalancePosition { get; set; }

        /// <summary>
        /// Amount of Batch Registrations (posição 171 a 176).
        /// </summary>
        public string? AmountBatchRegistrations { get; set; }

        /// <summary>
        /// Sum of Debt Values (posição 177 a 194).
        /// </summary>
        public string? SumDebtValues { get; set; }

        /// <summary>
        /// Sum of Credit Values (posição 195 a 212).
        /// </summary>
        public string? SumCreditValues { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN/CNAB (posição 213 a 240).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab3 { get; set; }
    }
}

