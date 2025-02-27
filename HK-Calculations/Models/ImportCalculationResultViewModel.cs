namespace HK_Calculations.Models
{
    public class ImportCalculationResultViewModel
    {
        public decimal FOBPrice { get; set; }
        public decimal FreightInsurance { get; set; }
        public decimal TotalBaseCost { get; set; }
        public decimal ArancelValue { get; set; }
        public decimal IVAImportacionValue { get; set; }
        public decimal RetencionIngresosBrutosValue { get; set; }
        public decimal GastosCertificacionValue { get; set; }
        public decimal DocumentacionValue { get; set; }
        public decimal FleteLocalValue { get; set; }
        public decimal HonorarioDespachanteValue { get; set; }
        public decimal OtrosGastosValue { get; set; }
        public decimal ImpuestoChequeValue { get; set; }
        public decimal TotalTaxesExpenses { get; set; }
        public decimal TotalCost { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal ProfitValue { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
