namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ClientXmlDto[] clientXmlDtos = context.Clients
                    .Where(c => c.Invoices.Any())
                    .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                    .OrderByDescending(c => c.Invoices.Count)
                    .ThenBy(c => c.Name)
                    .Select(c =>  new ClientXmlDto()
                    {
                        ClientName = c.Name,
                        VatNumber = c.NumberVat,
                        Invoices = c.Invoices
                                .OrderBy(c => c.IssueDate)
                                .ThenByDescending(c => c.DueDate)
                                .Select(i => new InvoiceXmlDto()
                                {
                                    InvoiceNumber = i.Number,
                                    InvoiceAmount = i.Amount,
                                    DueDate = i.DueDate.ToString("MM/dd/yyyy"),
                                    Currency = i.CurrencyType
                                })
                                .ToArray(),
                        InvoicesCount = c.Invoices.Count,

                    })
                    .ToArray();

            return xmlHelper.Serialize(clientXmlDtos, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var products = context.Products
                .Where(p => p.ProductsClients.Count > 0)
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))

                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                                .Where(cl => cl.Client.Name.Length >= nameLength)
                                .OrderBy(cl => cl.Client.Name)
                                .Select(cl => new
                                {
                                    cl.Client.Name,
                                    cl.Client.NumberVat
                                })
                                .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}