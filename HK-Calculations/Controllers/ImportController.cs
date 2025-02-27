using Microsoft.AspNetCore.Mvc;
using HK_Calculations.Models;

namespace HK_Calculations.Controllers
{
    public class ImportController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ImportCostViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(ImportCostViewModel model)
        {
            // Obtenemos manualmente los valores de los checkboxes desde Request.Form
            bool isArancelPorcentaje = Request.Form["ArancelIsPercentage"].ToString().ToLower().Contains("true");
            bool isIVAImportacionPorcentaje = Request.Form["IVAImportacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isRetencionPorcentaje = Request.Form["RetencionIngresosBrutosIsPercentage"].ToString().ToLower().Contains("true");
            bool isCertificacionPorcentaje = Request.Form["GastosCertificacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isDocumentacionPorcentaje = Request.Form["DocumentacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isFleteLocalPorcentaje = Request.Form["FleteLocalIsPercentage"].ToString().ToLower().Contains("true");
            bool isDespachantePorcentaje = Request.Form["HonorarioDespachanteIsPercentage"].ToString().ToLower().Contains("true");
            bool isOtrosGastosPorcentaje = Request.Form["OtrosGastosIsPercentage"].ToString().ToLower().Contains("true");
            bool isImpuestoChequePorcentaje = Request.Form["ImpuestoChequeIsPercentage"].ToString().ToLower().Contains("true");

            // Costo base: FOB + Flete y Seguro
            decimal baseCost = model.FOBPrice + model.FreightInsurance;

            // Para cada impuesto/gasto, si se marcó el checkbox se aplica el cálculo porcentual sobre el costo base;
            // de lo contrario, se usa el valor absoluto ingresado.
            decimal arancelValue = isArancelPorcentaje ? baseCost * model.Arancel / 100 : model.Arancel;
            decimal ivaValue = isIVAImportacionPorcentaje ? baseCost * model.IVAImportacion / 100 : model.IVAImportacion;
            decimal retencionValue = isRetencionPorcentaje ? baseCost * model.RetencionIngresosBrutos / 100 : model.RetencionIngresosBrutos;
            decimal certificacionValue = isCertificacionPorcentaje ? baseCost * model.GastosCertificacion / 100 : model.GastosCertificacion;
            decimal documentacionValue = isDocumentacionPorcentaje ? baseCost * model.Documentacion / 100 : model.Documentacion;
            decimal fleteLocalValue = isFleteLocalPorcentaje ? baseCost * model.FleteLocal / 100 : model.FleteLocal;
            decimal despachanteValue = isDespachantePorcentaje ? baseCost * model.HonorarioDespachante / 100 : model.HonorarioDespachante;
            decimal otrosGastosValue = isOtrosGastosPorcentaje ? baseCost * model.OtrosGastos / 100 : model.OtrosGastos;
            decimal impuestoChequeValue = isImpuestoChequePorcentaje ? baseCost * model.ImpuestoCheque / 100 : model.ImpuestoCheque;

            // Suma de impuestos y gastos
            decimal totalTaxesExpenses = arancelValue + ivaValue + retencionValue + certificacionValue +
                                         documentacionValue + fleteLocalValue + despachanteValue +
                                         otrosGastosValue + impuestoChequeValue;

            // Costo total (base + impuestos y gastos)
            decimal totalCost = baseCost + totalTaxesExpenses;

            // Cálculo del margen de utilidad y precio de venta
            decimal profitValue = totalCost * model.ProfitMargin / 100;
            decimal sellingPrice = totalCost + profitValue;

            // Preparamos el ViewModel de resultado
            var result = new ImportCalculationResultViewModel
            {
                FOBPrice = model.FOBPrice,
                FreightInsurance = model.FreightInsurance,
                TotalBaseCost = baseCost,
                ArancelValue = arancelValue,
                IVAImportacionValue = ivaValue,
                RetencionIngresosBrutosValue = retencionValue,
                GastosCertificacionValue = certificacionValue,
                DocumentacionValue = documentacionValue,
                FleteLocalValue = fleteLocalValue,
                HonorarioDespachanteValue = despachanteValue,
                OtrosGastosValue = otrosGastosValue,
                ImpuestoChequeValue = impuestoChequeValue,
                TotalTaxesExpenses = totalTaxesExpenses,
                TotalCost = totalCost,
                ProfitMargin = model.ProfitMargin,
                ProfitValue = profitValue,
                SellingPrice = sellingPrice
            };

            return View("Result", result);
        }
    }
}
