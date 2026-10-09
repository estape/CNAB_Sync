namespace ConfigModel
{
    public class Class_Config
    {
        /// <summary>
        /// Storage last opened files locations
        /// </summary>
        public string? LastPath { get; set; }

        /// <summary>
        /// Write with theme selected
        /// 0 = Light
        /// 1 = Dark
        /// 2 = System
        /// </summary>
        public int ThemeDefault { get; set; }
    }
}