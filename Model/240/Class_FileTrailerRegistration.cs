namespace CNAB240
{
    public class Class_FileTrailerRegistration
    {
        /// <summary>
        /// Bank Code in the Clearance House (posição 1 a 3).
        /// </summary>
        public string? BankCode { get; set; }

        /// <summary>
        /// Service Batch (posição 4 a 7).
        /// </summary>
        /// <value>9999</value>
        public string? ServiceBatch { get; set; }

        /// <summary>
        /// Type of Registration (posição 8 a 8).
        /// </summary>
        /// <value>9</value>
        public string? TypeOfRegistration { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 9 a 17).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab1 { get; set; }

        /// <summary>
        /// Amount of File Batches (posição 18 a 23).
        /// </summary>
        public string? AmountOfBatches { get; set; }

        /// <summary>
        /// Amount of File Registrations (posição 24 a 29).
        /// </summary>
        public string? AmountOfRegistrations { get; set; }

        /// <summary>
        /// Amount of Accounts of Balance (Batches) (posição 30 a 35).
        /// </summary>
        public string? AmountOfBalancedAccounts { get; set; }

        /// <summary>
        /// Exclusive Use by FEBRABAN / CNAB (posição 36 a 240).
        /// </summary>
        /// <value>Blanks</value>
        public string? Cnab2 { get; set; }
    }
}

