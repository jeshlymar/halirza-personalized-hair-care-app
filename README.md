# Halirza - Personalized Hair Care & Shopping Application

Halirza is a VB.NET Windows Forms desktop application that helps users explore hair-care products based on their questionnaire responses. The application combines personalized product matching with product browsing, filtering, a shopping cart, checkout calculations, and a loyalty-points system.

## Features

- **Hair-care questionnaire:** Collects hair type, curl pattern, texture, thickness, concerns, heat-tool usage, scalp issues, and hair goals.
- **Personalized recommendations:** Scores products using questionnaire answers and product titles and descriptions, then sorts the catalog by match score.
- **Product catalog:** Displays product images, descriptions, prices, and stock availability.
- **Catalog filtering:** Browse products by brand or product category.
- **Shopping cart:** Add products, update quantities, remove items, and preserve cart contents between application sessions.
- **Checkout:** Calculates subtotal, a 5% discount on orders over $200, 10% sales tax, and loyalty-point redemption.
- **Loyalty points:** Applies available points at checkout at a rate of one point per $1, then awards one point for each $10 paid after redemption.

## Technology Stack

- VB.NET
- .NET 8 (Windows)
- Windows Forms
- LINQ
- File I/O
- Visual Studio 2022

## Requirements

- Windows 10 or later
- Visual Studio 2022 with the **.NET desktop development** workload, or the .NET 8 SDK with Windows targeting support

## Run the Application

1. Clone this repository:
   ```bash
   git clone https://github.com/jeshlymar/halirza-personalized-hair-care-app.git
   ```
2. Open `Halirza.sln` in Visual Studio.
3. Restore and build the solution.
4. Run the project using Visual Studio.

Product images are copied to the build output directory automatically. Questionnaire responses, cart contents, and loyalty points are stored under the current Windows user's local application-data directory in `Halirza`, so the application does not depend on a specific developer's computer path.

## Project Structure

```text
.
|-- .github/
|-- Halirza/
|   |-- My Project/
|   |-- AppPaths.vb
|   |-- HalirzaQuestionnaire.vb
|   |-- HalirzaQuestionnaire.Designer.vb
|   |-- HalirzaQuestionnaire.resx
|   |-- HalirzaShopping.vb
|   |-- HalirzaShopping.Designer.vb
|   |-- HalirzaShopping.resx
|   |-- HalirzaCheckout.vb
|   |-- HalirzaCheckout.Designer.vb
|   |-- HalirzaCheckout.resx
|   |-- *.jpg
|   `-- Halirza.vbproj
|-- .gitignore
|-- Halirza.sln
`-- README.md
```

## Notes

- This is a desktop Windows Forms application; it is not a web or mobile application.
- Product recommendations use keyword-based matching, not a trained machine-learning model.
- Product prices and inventory are sample application data.
- Checkout is a local demonstration flow and does not process real payments.

## Author

Jeshlymar Vicente Maldonado
