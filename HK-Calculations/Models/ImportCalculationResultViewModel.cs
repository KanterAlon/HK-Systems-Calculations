using System.ComponentModel.DataAnnotations;

namespace HK_Calculations.Models
{
    public class ImportCalculationResultViewModel
    {
        [Display(Name = "Precio FOB")]
        public decimal FOBPrice { get; set; }

        [Display(Name = "Flete y Seguro")]
        public decimal FreightInsurance { get; set; }

        [Display(Name = "Costo Base (FOB + Flete y Seguro)")]
        public decimal TotalBaseCost { get; set; }

        [Display(Name = "Arancel")]
        public decimal ArancelValue { get; set; }

        [Display(Name = "IVA de Importación")]
        public decimal IVAImportacionValue { get; set; }

        [Display(Name = "Retención de Ingresos Brutos")]
        public decimal RetencionIngresosBrutosValue { get; set; }

        [Display(Name = "Gastos de Certificación")]
        public decimal GastosCertificacionValue { get; set; }

        [Display(Name = "Documentación")]
        public decimal DocumentacionValue { get; set; }

        [Display(Name = "Flete Local")]
        public decimal FleteLocalValue { get; set; }

        [Display(Name = "Honorario de Despachante de Aduana")]
        public decimal HonorarioDespachanteValue { get; set; }

        [Display(Name = "Otros Gastos")]
        public decimal OtrosGastosValue { get; set; }

        [Display(Name = "Impuesto al Cheque")]
        public decimal ImpuestoChequeValue { get; set; }

        [Display(Name = "Total Impuestos y Gastos")]
        public decimal TotalTaxesExpenses { get; set; }

        [Display(Name = "Costo Total (Base + Impuestos y Gastos + Instalación + Mantenimiento)")]
        public decimal TotalCost { get; set; }

        [Display(Name = "Margen de Utilidad (%)")]
        public decimal ProfitMargin { get; set; }

        [Display(Name = "Valor de Utilidad")]
        public decimal ProfitValue { get; set; }

        [Display(Name = "Precio de Venta")]
        public decimal SellingPrice { get; set; }

        // CAMPOS INTEGRADOS
        [Display(Name = "Instalación")]
        public decimal Instalacion { get; set; }

        [Display(Name = "Mantenimiento")]
        public decimal Mantenimiento { get; set; }
    }
}
