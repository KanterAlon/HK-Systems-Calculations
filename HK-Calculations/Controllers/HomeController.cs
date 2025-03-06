using Microsoft.AspNetCore.Mvc;
using HK_Calculations.Models;

namespace HK_Calculations.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ImportCostViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(ImportCostViewModel model)
        {
            // Obtenemos manualmente el estado de los checkboxes
            bool isArancelPorcentaje = Request.Form["ArancelIsPercentage"].ToString().ToLower().Contains("true");
            bool isIVAImportacionPorcentaje = Request.Form["IVAImportacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isRetencionPorcentaje = Request.Form["RetencionIngresosBrutosIsPercentage"].ToString().ToLower().Contains("true");
            bool isCertificacionPorcentaje = Request.Form["GastosCertificacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isDocumentacionPorcentaje = Request.Form["DocumentacionIsPercentage"].ToString().ToLower().Contains("true");
            bool isFleteLocalPorcentaje = Request.Form["FleteLocalIsPercentage"].ToString().ToLower().Contains("true");
            bool isDespachantePorcentaje = Request.Form["HonorarioDespachanteIsPercentage"].ToString().ToLower().Contains("true");
            bool isOtrosGastosPorcentaje = Request.Form["OtrosGastosIsPercentage"].ToString().ToLower().Contains("true");
            bool isImpuestoChequePorcentaje = Request.Form["ImpuestoChequeIsPercentage"].ToString().ToLower().Contains("true");

            // Costo base: Precio FOB + Flete y Seguro
            decimal baseCost = model.FOBPrice + model.FreightInsurance;

            // Cálculos: si el checkbox está marcado se usa el % sobre el costo base
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

            // Costo total: Base + Impuestos y Gastos + Instalación + Mantenimiento
            decimal totalCost = baseCost + totalTaxesExpenses + model.Instalacion + model.Mantenimiento;

            // Cálculo del margen y precio de venta
            decimal profitValue = totalCost * model.ProfitMargin / 100;
            decimal sellingPrice = totalCost + profitValue;

            // Preparar el modelo de resultados
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
                SellingPrice = sellingPrice,
                Instalacion = model.Instalacion,
                Mantenimiento = model.Mantenimiento
            };

            return View("Result", result);
        }

        [HttpPost]
        public IActionResult EditCalculation(ImportCalculationResultViewModel model)
        {
            // Convertir el modelo de resultados de vuelta al modelo de entrada para editar
            var importCostModel = new ImportCostViewModel
            {
                FOBPrice = model.FOBPrice,
                FreightInsurance = model.FreightInsurance,
                // Para la edición se toman los valores ya calculados
                Arancel = model.ArancelValue,
                IVAImportacion = model.IVAImportacionValue,
                RetencionIngresosBrutos = model.RetencionIngresosBrutosValue,
                GastosCertificacion = model.GastosCertificacionValue,
                Documentacion = model.DocumentacionValue,
                FleteLocal = model.FleteLocalValue,
                HonorarioDespachante = model.HonorarioDespachanteValue,
                OtrosGastos = model.OtrosGastosValue,
                ImpuestoCheque = model.ImpuestoChequeValue,
                ProfitMargin = model.ProfitMargin,
                Instalacion = model.Instalacion,
                Mantenimiento = model.Mantenimiento
            };

            return View("Index", importCostModel);
        }

        // Otros métodos (como Privacy, Error, etc.) se pueden dejar según tu configuración.
    }
}
