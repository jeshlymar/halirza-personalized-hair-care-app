# Halirza – Personalized Hair Care & Shopping Application

Halirza is a VB.NET Windows Forms desktop application that helps users explore hair-care products based on their questionnaire responses. The application combines a personalized product-matching experience with product browsing, filtering, a shopping cart, checkout calculations, and a loyalty-points system.

## Features

- **Hair-care questionnaire:** collects hair type, curl pattern, texture, thickness, concerns, heat-tool usage, scalp issues, and hair goals.
- **Personalized recommendations:** scores products using questionnaire answers and product titles/descriptions, then sorts the catalog by match score.
- **Product catalog:** displays product images, descriptions, prices, and stock availability.
- **Catalog filtering:** browse products by brand or product category.
- **Shopping cart:** add products, update quantities, remove items, and preserve cart contents between application sessions.
- **Checkout:** calculates subtotal, a 5% discount on orders over $200, 10% sales tax, and loyalty-point redemption.
- **Loyalty points:** applies available points at checkout at a rate of one point per $1, then awards one point for each $10 paid after redemption.

## Technology Stack

- VB.NET
- .NET 8 (Windows)
- Windows Forms
- LINQ
- File I/O
- Visual Studio

## Requirements

- Windows 10 or later
- Visual Studio 2022 with the **.NET desktop development** workload, or the .NET 8 SDK with Windows targeting support

## Run the Application

1. Clone this repository:
   ```bash
   git clone <YOUR_REPOSITORY_URL>
   ```
2. Open `Vicente_Maldonado_Capstone_Project.sln` in Visual Studio.
3. Restore/build the solution.
4. Run the project using Visual Studio.

The product images are copied to the build output directory automatically. Questionnaire responses, cart contents, and loyalty points are stored under the current Windows user's local application-data directory in `Halirza` so the application does not depend on a specific developer's computer path.

## Project Structure

```text
Halirza/
├── README.md
├── .gitignore
├── Vicente_Maldonado_Capstone_Project.sln
└── Vicente_Maldonado_Capstone_Project/
    ├── AppPaths.vb
    ├── Form1.vb / Form1.Designer.vb       # Questionnaire
    ├── Form2.vb / Form2.Designer.vb       # Product catalog and cart
    ├── Form3.vb / Form3.Designer.vb       # Checkout and loyalty points
    ├── *.resx                              # Windows Forms resources
    ├── *.jpg                               # Product images
    └── *.vbproj
```

## Notes

- This is a desktop Windows Forms application; it is not a web or mobile application.
- Product recommendations are keyword-based matching, not a trained machine-learning model.
- Product prices and inventory are sample application data.
- Checkout is a local demonstration flow and does not process real payments.

## Author

Jeshlymar Vicente Maldonado
