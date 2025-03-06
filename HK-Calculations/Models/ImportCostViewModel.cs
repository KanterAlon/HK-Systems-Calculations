using System.ComponentModel.DataAnnotations;

namespace HK_Calculations.Models
{
    public class ImportCostViewModel
    {
        [Display(Name = "Precio FOB")]
        public decimal FOBPrice { get; set; }

        [Display(Name = "Flete y Seguro")]
        public decimal FreightInsurance { get; set; }

        [Display(Name = "Arancel")]
        public decimal Arancel { get; set; }
        public bool ArancelIsPercentage { get; set; }

        [Display(Name = "IVA de Importación")]
        public decimal IVAImportacion { get; set; }
        public bool IVAImportacionIsPercentage { get; set; }

        [Display(Name = "Retención de Ingresos Brutos")]
        public decimal RetencionIngresosBrutos { get; set; }
        public bool RetencionIngresosBrutosIsPercentage { get; set; }

        [Display(Name = "Gastos de Certificación")]
        public decimal GastosCertificacion { get; set; }
        public bool GastosCertificacionIsPercentage { get; set; }

        [Display(Name = "Documentación")]
        public decimal Documentacion { get; set; }
        public bool DocumentacionIsPercentage { get; set; }

        [Display(Name = "Flete Local")]
        public decimal FleteLocal { get; set; }
        public bool FleteLocalIsPercentage { get; set; }

        [Display(Name = "Honorario de Despachante de Aduana")]
        public decimal HonorarioDespachante { get; set; }
        public bool HonorarioDespachanteIsPercentage { get; set; }

        [Display(Name = "Otros Gastos")]
        public decimal OtrosGastos { get; set; }
        public bool OtrosGastosIsPercentage { get; set; }

        [Display(Name = "Impuesto al Cheque")]
        public decimal ImpuestoCheque { get; set; }
        public bool ImpuestoChequeIsPercentage { get; set; }

        [Display(Name = "Margen de Utilidad (%)")]
        public decimal ProfitMargin { get; set; }

        // CAMPOS INTEGRADOS
        [Display(Name = "Instalación")]
        public decimal Instalacion { get; set; }

        [Display(Name = "Mantenimiento")]
        public decimal Mantenimiento { get; set; }
    }
}
