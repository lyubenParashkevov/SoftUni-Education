namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Client> clients = new List<Client>();

            XmlHelper xmlHelper = new XmlHelper();
            ClientDto[] clientDtos = xmlHelper.Deserialize<ClientDto[]>(xmlString, "Clients");

            foreach (ClientDto clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Address> addresses = new List<Address>();
                foreach (AddressDto addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country
                    };
                    addresses.Add(address);
                }
                Client client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                    Addresses = addresses
                };
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, clientDto.Name));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Invoice> invoices = new List<Invoice>();
            InvoiceDto[] invoiceDtos = JsonConvert.DeserializeObject<InvoiceDto[]>(jsonString);

            foreach (InvoiceDto invoiceDto in invoiceDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(invoiceDto.IssueDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(invoiceDto.DueDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Clients.Any(cl => cl.Id == invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId
                };

                invoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Product> products = new List<Product>();

            ProductDto[] productDtos = JsonConvert.DeserializeObject<ProductDto[]>(jsonString);

            foreach (ProductDto productDto in productDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = productDto.CategoryType,
                };

                ICollection<ProductClient> productClients = new List<ProductClient>();


                foreach (int clientId in productDto.Clients.Distinct())
                {
                    Client clientToFind = context.Clients.Find(clientId);
                    if (clientToFind == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProductClient productClient = new ProductClient()
                    {
                        //Product = product,
                        //ClientId = clientId,
                        Client = clientToFind,
                    };
                    productClients.Add(productClient);
                }
                product.ProductsClients = productClients;

                products.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, productDto.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
