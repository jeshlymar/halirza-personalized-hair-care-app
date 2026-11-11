Imports System.IO
Imports System.Linq

Public Class HalirzaShopping
    'Read the information in the file if it exists and add the information in the file to a list called answers
    Private Function LoadQuestionnaireAnswers(filePath As String) As List(Of String)
        Dim answers As New List(Of String)

        If File.Exists(filePath) Then
            Dim allLines = File.ReadAllLines(filePath)
            If allLines.Length > 0 Then
                Dim lastLine = allLines.Last()
                Dim parts = lastLine.Split(","c)

                For Each part In parts
                    Dim colonIndex = part.IndexOf(":"c)
                    If colonIndex > -1 Then
                        Dim value = part.Substring(colonIndex + 1).Trim()
                        answers.Add(value.ToLower())
                    End If
                Next
            End If
        End If

        Return answers
    End Function

    'Give points to each product based on the title and description to know where each product is going to
    'fall in the list. This is used to order the list of products by the information from the file that holds
    'the quiz answers
    Private Function GetProductScore(product As Product, answers As List(Of String)) As Integer
        Dim score As Integer = 0
        Dim title = product.Title.ToLower()
        Dim description = product.Description.ToLower()

        For Each answer In answers
            If title.Contains(answer) Then score += 2
            If description.Contains(answer) Then score += 1
        Next

        Return score
    End Function

    'Load the form and create the scrollable panel. Additionally load the test answers and sort them based on the
    'title and description and how closely it matches the answers. Call the displayProducts function to display the products on the panel

    Private Sub HalirzaShopping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppPaths.EnsureDataDirectory()
        pnlProductList.AutoScroll = True
        Dim answers As List(Of String) = LoadQuestionnaireAnswers(AppPaths.GoalsFile)

        ' Sort products by match score
        Dim sortedProducts = products.OrderByDescending(Function(p) GetProductScore(p, answers)).ToList()

        ' Display products
        DisplayProducts(sortedProducts)
        'DisplayProducts(products)
    End Sub

    Public Shared Property UserHairType As String
    Public Shared Property UserCurlPattern As String
    Public Shared Property UserHairTexture As String
    Public Shared Property UserHairThickness As String
    Public Shared Property UserHairConcerns As String
    Public Shared Property UserHeatTools As String
    Public Shared Property UserScalpIssues As String
    Public Shared Property UserHairGoals As String

    'This class stores all the properties of each product
    Private Class Product
        Public Property ProductType As String
        Public Property Brand As String
        Public Property Title As String
        Public Property Description As String
        Public Property ImagePath As String
        Public Property Stock As Integer
        Public Property Price As Double
        Public Property Quantity As Integer

    End Class

    'a List of the products with their information
    Dim products As New List(Of Product) From {
        New Product With {.ProductType = "Gel", .Brand = "Shea Moisture", .Title = "Shea Moisture: Papaya And Neroli All Day Frizz Control Style Gel", .Description = "This Non-Alcohol Styling Gel Keeps Waves And Curls Defined And Hydrated. Frizzy Curls Smooth Out With This Formula Infused With Straight-From-Paradise Papaya, Juicy Neroli, ElderfLower And Fair-Trade Shea Butter. Provides All Day Hold And Beautiful Shine, Without The Hard Crunch Or Flakes. Leaves Natural Waves And Curls Looking Gorgeous. ", .ImagePath = AppPaths.GetProductImage("FrizzStylingGel.jpg"), .Stock = 7, .Price = 16.99, .Quantity = 0},
        New Product With {.ProductType = "Gel", .Brand = "Shea Moisture", .Title = "Shea Moisture: Papaya And Neroli All Day Frizz Control Milk Gel", .Description = "Papaya And Neroli Milk Gel Is A Natural Hair Gel, Styling Gel And Hair Gel For Wavy, Curly Hair. This Curl Gel Adds A Dose Of Moisture And Shine, With Complete Frizz Control. Block Out Humidity With This Paraben-Free Curl Gel, Styling Gel And Humidity-Resistant Milk Gel. It Defines Hair For Smooth, Silky Curls And Waves. ", .ImagePath = AppPaths.GetProductImage("FrizzMilkGel.jpg"), .Stock = 7, .Price = 10.87, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "Shea Moisture", .Title = "Shea Moisture: Papaya And Neroli All Day Frizz Control Shampoo", .Description = "The First Step In Fighting Frizz Is With Our Gentle Cleansing Papaya And Neroli All Day Frizz Control Shampoo. Our Formula Provides An All-Day  Frizz Reduction When Used As Step 1 In Our All Day Frizz Control Regimen. Infused With Straight-From-Paradise Papaya, Juicy Neroli, Elderflower, And Fair-Trade Shea Butter, Our Shampoo Helps To Keep Hair Feeling Clean, Hydrated, And Smooth.", .ImagePath = AppPaths.GetProductImage("FrizzShampoo.jpg"), .Stock = 4, .Price = 8.77, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "Shea Moisture", .Title = "Shea Moisture: Papaya And Neroli All Day Frizz Control Conditioner", .Description = "Control And reduce Frizz With Our papaya And neroli All day Frizz Control Conditioner. This Tropical Conditioner Helps Defend Hair From Unwanted Frizz And Flyways When Used As Step 2 Of Our All Day Frizz Control Regimen. Infused With Straight-From-Paradise Papaya, Juicy Neroli, Elderflower And Fair-Trade Shea Butter, Our Conditioner Locks In Moisture And Smooths Out Strands Leaving Hair Super Soft And Manageable", .ImagePath = AppPaths.GetProductImage("FrizzConditioner.jpg"), .Stock = 8, .Price = 13.8, .Quantity = 0},
        New Product With {.ProductType = "Detangler", .Brand = "Shea Moisture", .Title = "Shea Moisture: Low Porosity Weightless Leave-In Detangler", .Description = "This Multitasking Detangler Conditions Hair While Unraveling Tangles And Knots For Easy Comb-Through. ", .ImagePath = AppPaths.GetProductImage("LowPorosityDetangler.jpg"), .Stock = 10, .Price = 13.94, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "Shea Moisture", .Title = "Shea Moisture: Manuka Honey And Mafura Oil Intensive Hydration And Care Leave-In Conditioner", .Description = "Hydrate And Smooth ", .ImagePath = AppPaths.GetProductImage("IntensiveLeaveInConditioner.jpg"), .Stock = 5, .Price = 14.99, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "Shea Moisture", .Title = "Shea Moisture: Low Porosity Weightless Hydrating Shampoo", .Description = "This Clarifying, Lightweight Hair Shampoo Is Ideal For Low Porosity, Protein-Sensitive Curls And Coils That Resist Essential Moisture", .ImagePath = AppPaths.GetProductImage("LowPorosityShampoo.jpg"), .Stock = 4, .Price = 12.49, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "Shea Moisture", .Title = "Shea Moisture: Low Porosity Weightless Hydrating Conditioner", .Description = "This Hair Conditioner Is Ideal For Low-Porosity And Protein-Sensitive Curls And Coils That Are Resistant To Essential Moisture ", .ImagePath = AppPaths.GetProductImage("LowPorosityConditioner.jpg"), .Stock = 0, .Price = 13.79, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "Shea Moisture", .Title = "Shea Moisture: High Porosity Moisture Replenish Shampoo", .Description = "This Ultra-Hydrating Hair Shampoo Replenishes Dry And Damaged Strands", .ImagePath = AppPaths.GetProductImage("HighPorosityShampoo.jpg"), .Stock = 5, .Price = 14.06, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "Shea Moisture", .Title = "Shea Moisture: High Porosity Moisture Replenish Masque", .Description = "This Deep Conditioner Helps Hair Hold On To Moisture While Forming A Protective Layer Over Dry, Damaged Hair.", .ImagePath = AppPaths.GetProductImage("HighPorosityMasque.jpg"), .Stock = 3, .Price = 15.16, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Ouai", .Title = "Ouai: Anti Frizz Crème", .Description = "Provides Immediate Frizz Reduction And Lasts Up To 72 Hours. Provides Heat Protection Up To 450 Degrees Fahrenheit. Moisturizes And Hydrates Hair. Reduces And Helps Repair Split Ends", .ImagePath = AppPaths.GetProductImage("OuaiAntiFrizzCreme.jpg"), .Stock = 6, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "Ouai", .Title = "Ouai: Anti-Dandruff Shampoo", .Description = "Our New Anti-Dandruff Shampoo Uses 2% Salicylic Acid To Fight Flakes, Itching And Irritation From Dandruff And Soothe Dry Scalps. ", .ImagePath = AppPaths.GetProductImage("OuaiDandruffShampoo.jpg"), .Stock = 2, .Price = 38.0, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "Ouai", .Title = "Ouai: Fine Hair Shampoo", .Description = "This Color-Safe Shampoo Breathes Life Into Fine, Flat Hair With Strengthening Keratin, Biotin, And Nourishing Chia Seed Oil. Hair Is Left Clean, Bouncy, And Full Of Volume, So You Can Finally Be Fine With Being Fine.", .ImagePath = AppPaths.GetProductImage("OuaiFineShampoo.jpg"), .Stock = 5, .Price = 32.0, .Quantity = 0},
        New Product With {.ProductType = "Mousse", .Brand = "Ouai", .Title = "Ouai: Air Dry Foam", .Description = "Perfect For Naturally Wavy Hair. This Time-Saving Foam Lets You Skip The Hot Tools For Perfectly Air Dried, Frizz-Free, Beachy Waves And Curls. It’s Packed With Kale Extract, So Your Curls Won’t Get Crunchy, Giving Hair A Defined, Natural Finish That’ll Make Your Curling Irons Jealous", .ImagePath = AppPaths.GetProductImage("OuaiAirDryFoam.jpg"), .Stock = 2, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Ouai", .Title = "Ouai: Curl Crème", .Description = "For Our Curl Friends, This Silicone-Free Cream That Defines Curls, Tames Frizz, And Adds Shine To All Curl Types. Curl Crème’s Key Ingredients Lensed And Chia Seed Collab To Shape Curls While Maintaining The Hair’s Natural Texture And Protecting Hair From Humidity. ", .ImagePath = AppPaths.GetProductImage("OuaiCurlCreme.jpg"), .Stock = 0, .Price = 32.0, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "Ouai", .Title = "Ouai: Scalp serum", .Description = "It Helps Support The Appearance Of Thicker, Healthier Hair. Featuring Adaptogens Like Arctic Root, Siberian Ginseng And Chaga Mushroom Combined With Hyaluronic Acid, This Serum Can Help Promote Hydration And A Healthy Barrier", .ImagePath = AppPaths.GetProductImage("OuaiScalpSerum.jpg"), .Stock = 2, .Price = 28.95, .Quantity = 0},
        New Product With {.ProductType = "Gloss", .Brand = "Ouai", .Title = "Ouai: Hair Gloss", .Description = "Glow All Out. This Multi-Tasking At Home Hair Gloss Will Give You An Immediate Shine While Providing Healthy Hair Benefits Like Protecting Against Color Fading, Helping Treat Damage And Providing Heat Protection.", .ImagePath = AppPaths.GetProductImage("OuaiHairGloss.jpg"), .Stock = 4, .Price = 34.0, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "Ouai", .Title = "Ouai: Leave-in Conditioner", .Description = "This Frizz-Fighting Leave In Conditioner With Thermal Protection Repairs Dry Ends And Protects Against Breakage, While Adding Slip To Hair For Seamless Detangling. Use It As A Pre-Heat Styling Primer Or As Part Of Your Wash And Go Routine For Healthy, Radiant Hair.", .ImagePath = AppPaths.GetProductImage("OuaiLeaveInConditioner.jpg"), .Stock = 5, .Price = 30.0, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "PATTERN", .Title = "PATTERN: Breakage Barrier Hair Mask", .Description = "A Nutrient-Dense Mask That Prevents Breakage And Maintains Moisture Balance. Infused With White Tea To Help Prevent Damage, Breakage, And Maintain Moisture Balance. ", .ImagePath = AppPaths.GetProductImage("BarrierHairMask.jpg"), .Stock = 6, .Price = 25.0, .Quantity = 0},
        New Product With {.ProductType = "Gel", .Brand = "PATTERN", .Title = "PATTERN: Curl Gel", .Description = "Flexible And Creamy Gel That Defines Curls With A Touchable Medium Hold That Is Crunch And Flake-Free. Crafted With Aloe Vera, Coconut Oil And Cacao Oil Curls Are Left Defined, Springy, Juicy, And Joyful.", .ImagePath = AppPaths.GetProductImage("CurlGel.jpg"), .Stock = 3, .Price = 26.49, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "PATTERN", .Title = "PATTERN: Deep Scalp Detox", .Description = "Restores Scalp Health With A 2 In 1 Serum Crafted With Australian Tea Tree Oil,  Balancing Pink Clay And Lemon Peel Oil To Purge Dirt Dead Skin And Lingering Product Naturally, Ideal For A Reset In Between Wash Days During Or After Braids, Wigs, And Weaves", .ImagePath = AppPaths.GetProductImage("ScalpDetox.jpg"), .Stock = 5, .Price = 29.0, .Quantity = 0},
        New Product With {.ProductType = "Mousse", .Brand = "PATTERN", .Title = "PATTERN: Curl Mousse", .Description = "Ultra-Light Mousse That Defines Curls, And Weightless Volume And Shine While Maintaining Softness And Smoothness. Crafted From Marshmallow Root And Castor Oil This Mousse Is Ideal For Wash And Go’s Protective Styles Finger Weaves And More.", .ImagePath = AppPaths.GetProductImage("CurlMousse.jpg"), .Stock = 4, .Price = 23.0, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "PATTERN", .Title = "PATTERN: Styling Cream", .Description = "An Oil Rich And Super Thick Cream That Provides Superior Moisture And Curl Definition On Coily And Tightly Textured Hair. Formulated With Shea Butter, Cacao Oil And Sweet Almond Oil Which Help Prevent Breakage And Damage", .ImagePath = AppPaths.GetProductImage("StylingCream.jpg"), .Stock = 5, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Heat", .Brand = "PATTERN", .Title = "PATTERN: Heat Protectant", .Description = "Shield Your Curls And Coils From Heat Damage With Our Lightweight, Silky Heat Protectant. Infused With Nourishing Ingredients, It Adds A Healthy Luster For Beautifully Protected Hair.", .ImagePath = AppPaths.GetProductImage("HeatProtectant.jpg"), .Stock = 6, .Price = 20.0, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "PATTERN", .Title = "PATTERN: Revitalizing Scalp Scrub", .Description = "Infused With Pink Himalayan Sea Salt And A Blend Of Cucumber, Fenugreek, And Ginger Root Extracts To Gently Exfoliate The Scalp, Removing Excess Oil, Flakes, And Product Buildup. This Easy-Rinse Formula Leaves Your Hair Crown Refreshed, Hydrated, And Itch-Free.", .ImagePath = AppPaths.GetProductImage("ScalpScrub.jpg"), .Stock = 4, .Price = 29.0, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "PATTERN", .Title = "PATTERN: Moisture Milk", .Description = "Lightweight Cream Provides Long Lasting Moisture Ro Dry Hair, Reduces Breakage And Keeps Unwanted Frizz At Bay. Crafted With Key Ingredients Like Rich Amla Oil, Irish Moss And Agave Nectar, Moisture Milk Is Perfect For Providing Daily Moisture To Curly Hair And Refreshing Twist Outs And Wash And Go’s For The Ultimate Shine.", .ImagePath = AppPaths.GetProductImage("MoistureMilk.jpg"), .Stock = 4, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "PATTERN", .Title = "PATTERN: Jojoba Oil Blend", .Description = "Helps Curls Retain Moisture, Reduce Hair Breakage, And Ease An Itchy Or Dry Scalp With This Lightweight And Residue-Free Hair Oil Made With A Blend Of Safflower Oil, Rosehip Oil, Olive Oil And Lavender Oil And Jojoba Oil For Hair. This Formula Helps Nourish The Hair Shaft For Overall Hair Health.", .ImagePath = AppPaths.GetProductImage("JojobaOilBlend.jpg"), .Stock = 0, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "PATTERN", .Title = "PATTERN: Argan Oil Blend", .Description = "Transform Your Hair With Our Lightweight, Residue-Free Argan Oil Blend. Enhanced With A Powerful Mix of Oils Including Argan, Sunflower, And Shea. It Strengthens, Hydrates, And Keeps Curls Soft And Smooth. Embrace Healthier, More Resilient Curls Today.", .ImagePath = AppPaths.GetProductImage("ArganOilBlend.jpg"), .Stock = 0, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "Skala", .Title = "Skala: Linha Expert – Gel Liquid Mais Cachos Masque", .Description = "Strengthens And Assists In The Fight Against Hair Loss Due To Hair Breakage", .ImagePath = AppPaths.GetProductImage("LinhaGelLiquid.jpg"), .Stock = 4, .Price = 10.99, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "Skala", .Title = "Skala: Skala Expert Bomba De Vitaminas Masque", .Description = "Boost Hair Growth Naturally; Infused With Powerful Vitamins And Nutrients, Skala Expert Vitamins Blast Promotes Faster, Healthier Hair Growth While Strengthening Strands", .ImagePath = AppPaths.GetProductImage("BombaDeVitaminas.jpg"), .Stock = 5, .Price = 10.56, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Amido De Milho Conditioning Cream", .Description = "Skala Amido Mask From Milho Provides Repair, Strength, And Shine To All Types Of Hair. This Line With Cornstarch Is Ultra Repairing, It Helps To Strengthen And Make Hair Shine.", .ImagePath = AppPaths.GetProductImage("AmidoDeMilho.jpg"), .Stock = 0, .Price = 12.95, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "Skala", .Title = "Skala: Skala Divino Potao For Curly Hair Treatment Mask", .Description = "Castor Oil Strengthens And Helps Fight Hair Loss Due To Hair Breakage And Argan Oil Provides Ultra Repair And Shine", .ImagePath = AppPaths.GetProductImage("DivinoPotao.jpg"), .Stock = 6, .Price = 10.99, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Impecavel Ceramidas G3 Hair Treatment Conditioning Crème", .Description = "Vitality And Shine. Seals Cuticles, Strengthens Hair Structure, And Decreases Porosity And Frizz Keeping Hair Healthy And Nourished.", .ImagePath = AppPaths.GetProductImage("ImpecavelCeramidas.jpg"), .Stock = 3, .Price = 14.43, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Expert Mais Cachos", .Description = "Nutrient-Rich Curl Cream Designed To Define And Enhance Curls, Coils, And Waves Of All Types While Controlling Frizz And Flyaways", .ImagePath = AppPaths.GetProductImage("ExpertMaisCachos.jpg"), .Stock = 5, .Price = 9.98, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Crema Para Peinar Mais Lisos", .Description = "This Powerful Straightening Cream Is Especially Designed To Help Even The Curliest, Most Unruly Hair Become Straight, Smooth, And Totally Frizz-Free", .ImagePath = AppPaths.GetProductImage("MaisLisos.jpg"), .Stock = 4, .Price = 12.68, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Café Verde Hair Cream", .Description = "Designed To Boost Hair Growth, Strengthen Weak, Damaged Hair, Increase Hydration, Reduce Frizz, Smooth Hair Texture, Add Shine, And Improve Scalp Health", .ImagePath = AppPaths.GetProductImage("CafeVerde.jpg"), .Stock = 3, .Price = 11.99, .Quantity = 0},
        New Product With {.ProductType = "Masque", .Brand = "Skala", .Title = "Skala: Skala Botanica Jaborandi Scarabotanica Masque", .Description = "This Mask MoIsturizes Hair With Strengthening Emollients Like Shea Butter, Babassu Oil And Mantecado Cream. It Increases Circulation And Stimulates Growth Factors. It Also Protects Hair From Free Radical Damage And Draws Out Impurities From The Scalp And Strands.", .ImagePath = AppPaths.GetProductImage("Botanica.jpg"), .Stock = 0, .Price = 12.99, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "Skala", .Title = "Skala: Skala Crème De Nutricao Bomba De Biotina", .Description = "A Powerful Deep Conditioning Treatment That Helps Strengthen And Restore Weakened, Thinning Hair", .ImagePath = AppPaths.GetProductImage("BombaDeBiotina.jpg"), .Stock = 6, .Price = 13.78, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "CURLSMITH", .Title = "CURLSMITH: Curlshield Cream ", .Description = "A Nourishing Cream That Creates A Protective Barrier Against Heat Damage While Improving Split Ends Instantly", .ImagePath = AppPaths.GetProductImage("CurlshieldCream.jpg"), .Stock = 6, .Price = 29.0, .Quantity = 0},
        New Product With {.ProductType = "Gel", .Brand = "CURLSMITH", .Title = "CURLSMITH: Fragrance Free Strong Hold Gel ", .Description = "A Fragrance-Free Long-Lasting Styling Gel, Dermatologically Tested, That Provides Frizz Control And Definition To Keep Your Style In Place", .ImagePath = AppPaths.GetProductImage("StrongHoldGel.jpg"), .Stock = 4, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Cream", .Brand = "CURLSMITH", .Title = "CURLSMITH: Weightless Air-Dry Cream", .Description = "Lightweight Leave-In Conditioner That Enhances Curly Texture And Hydrates The Hair Without Weighing It Down", .ImagePath = AppPaths.GetProductImage("AirDryCream.jpg"), .Stock = 4, .Price = 12.5, .Quantity = 0},
        New Product With {.ProductType = "Gel", .Brand = "CURLSMITH", .Title = "CURLSMITH: Curl Defining Styling Souffle", .Description = "Buildable Hold Curl Styling Gel That Provides Moisture, Shine, And Flexible Definition For All Curl types", .ImagePath = AppPaths.GetProductImage("StylingSouffle.jpg"), .Stock = 0, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "CURLSMITH", .Title = "CURLSMITH: Curl Quenching Conditioning Wash", .Description = "2 In1 Shampoo And Conditioner That Gently Cleanses Hair Without Stripping It Of Natural Oils", .ImagePath = AppPaths.GetProductImage("ConditioningWash.jpg"), .Stock = 3, .Price = 26.0, .Quantity = 0},
        New Product With {.ProductType = "Mousse", .Brand = "CURLSMITH", .Title = "CURLSMITH: Bouncy Strength Volume Foam ", .Description = "Lightweight Protein-Enriched Styler That Provides Soft Hold And Volume While Enhancing Your Natural Hair Texture", .ImagePath = AppPaths.GetProductImage("VolumeFoam.jpg"), .Stock = 3, .Price = 28.0, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "CURLSMITH", .Title = "CURLSMITH: Bond Curl Rehab Salve", .Description = "An Intense Pre-Shampoo Treatment, Loaded With Amino Acids, Which Will Help Repair Hydrate, And Protect Your Hair Against Damage ", .ImagePath = AppPaths.GetProductImage("RehabSalve.jpg"), .Stock = 5, .Price = 26.0, .Quantity = 0},
        New Product With {.ProductType = "Shampoo", .Brand = "CURLSMITH", .Title = "CURLSMITH: Core strength Shampoo", .Description = "Protein-Enriched Gentle Cleanser That Melts Dirt And Build-Up To Help Hair Look Stronger And More Resilient.", .ImagePath = AppPaths.GetProductImage("StrengthShampoo.jpg"), .Stock = 3, .Price = 26.0, .Quantity = 0},
        New Product With {.ProductType = "Conditioner", .Brand = "CURLSMITH", .Title = "CURLSMITH: Hydrate And Plump Leave-In Conditioner", .Description = "A Leave-In Conditioner That Nourishes The Cortex To Help Plump Hair And Boost Volume, For Big Bouncy, Moisturized Curls", .ImagePath = AppPaths.GetProductImage("PlumpLeaveIn.jpg"), .Stock = 0, .Price = 27.0, .Quantity = 0},
        New Product With {.ProductType = "Scalp", .Brand = "CURLSMITH", .Title = "CURLSMITH: Scalp Stimulating Booster", .Description = "Daily Scalp Serum That Balances The Scalp And Promotes Healthier, Fuller, Thicker, And Longer-Looking Hair", .ImagePath = AppPaths.GetProductImage("StimulatingBooster.jpg"), .Stock = 4, .Price = 21.0, .Quantity = 0}
    }



    'Create the panels for each product with their respective information and add the information into the panel
    Private Sub DisplayProducts(products As List(Of Product))
        Dim yOffset As Integer = 10
        For Each product In products
            ' Create a container Panel for each product
            Dim productPanel As New Panel With {
                .Width = pnlProductList.Width - 40,
                .Height = 180,
                .Left = 10,
                .Top = yOffset,
                .BorderStyle = BorderStyle.FixedSingle
            }

            ' Title
            Dim lblTitle As New Label With {
                .Text = product.Title,
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .Top = 10,
                .Left = 120,
                .AutoSize = True
            }

            ' Description
            Dim lblDesc As New Label With {
                .Text = product.Description,
                .Left = 120,
                .Top = 40,
                .Width = 600,
                .Height = 90
            }
            Dim btnAddToCart As New Button With {
                .Text = "Add to Cart",
                .Top = 140,
                .Left = 300,
                .AutoSize = True,
                .Tag = product
            }
            AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

            ' Stock Status
            Dim lblStock As New Label With {.Left = 120, .Top = 140, .AutoSize = True}
            If product.Stock = 0 Then
                btnAddToCart.Enabled = False
                btnAddToCart.Text = "Out of Stock"
            End If

            ' Image
            Dim pic As New PictureBox With {
            .Image = Image.FromFile(product.ImagePath),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Width = 100,
            .Height = 100,
            .Left = 10,
            .Top = 20
            }

            ' Price
            Dim lblPrice As New Label With {
                .Text = product.Price,
                .Top = 130,
                .Left = 10
            }
            'Dim cart As New Button With {
            '.Visible = True,
            '.Text = "Add To Cart",
            '.AutoSize = True,
            '.Left = 120,
            '.Top = 120
            '}



            ' Add controls to product panel
            productPanel.Controls.Add(lblTitle)
            productPanel.Controls.Add(lblDesc)
            productPanel.Controls.Add(lblStock)
            productPanel.Controls.Add(pic)
            productPanel.Controls.Add(lblPrice)
            productPanel.Controls.Add(btnAddToCart)

            ' Add to main scrollable panel
            pnlProductList.Controls.Add(productPanel)

            yOffset += productPanel.Height + 10
        Next
        ' Create a checkout button and the handler for it and add it to the panel
        Dim btnCheckout As New Button With {
            .Text = "Go To Checkout",
            .AutoSize = True,
            .Top = yOffset + 10,
            .Left = 10
        }
        AddHandler btnCheckout.Click, AddressOf Checkout_Click
        pnlProductList.Controls.Add(btnCheckout)

    End Sub
    'When the user clicks he checkout button, they are directed to the checkout form and the shopping form is hidden
    Private Sub Checkout_Click(sender As Object, e As EventArgs)
        Dim halirzaCheckout As New HalirzaCheckout()
        halirzaCheckout.Show()
        Me.Hide()
    End Sub

    'When the user clicks add to cart on any product, we make sure that item is in stock and add it to the cart once we open the cart file.
    'If its already in the cart, increase the quantity and decrease the stock amount
    Private Sub AddToCart_Click(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim selectedProduct As Product = DirectCast(button.Tag, Product)

        If selectedProduct.Stock <= 0 Then
            MessageBox.Show("This Product Is Out Of Stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Decrement stock and increase quantity
        selectedProduct.Stock -= 1
        selectedProduct.Quantity += 1

        ' Update button state if out of stock
        Dim parentPanel As Panel = DirectCast(button.Parent, Panel)
        For Each ctrl As Control In parentPanel.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl As Label = DirectCast(ctrl, Label)
                If selectedProduct.Stock = 0 Then
                    button.Enabled = False
                    button.Text = "Out Of Stock"
                End If
            End If
        Next

        ' Load existing cart
        AppPaths.EnsureDataDirectory()
        Dim cartPath As String = AppPaths.CartFile
        Dim cartItems As New List(Of Product)

        If File.Exists(cartPath) Then
            Dim lines() As String = File.ReadAllLines(cartPath)
            For Each line In lines
                Dim parts() As String = line.Split("|"c)
                If parts.Length >= 6 Then
                    cartItems.Add(New Product With {
                        .Title = parts(0),
                        .Description = parts(1),
                        .ImagePath = AppPaths.GetProductImage(parts(2)),
                        .Price = Decimal.Parse(parts(3), Globalization.CultureInfo.InvariantCulture),
                        .Quantity = CInt(parts(4)),
                        .Stock = CInt(parts(5))
                    })
                End If
            Next
        End If

        ' Check if product already exists
        Dim existingItem = cartItems.FirstOrDefault(Function(p) p.Title = selectedProduct.Title)

        If existingItem IsNot Nothing Then
            existingItem.Quantity += 1
            existingItem.Stock -= 1
        Else
            cartItems.Add(New Product With {
                .Title = selectedProduct.Title,
                .Description = selectedProduct.Description,
                .ImagePath = selectedProduct.ImagePath,
                .Price = selectedProduct.Price,
                .Quantity = selectedProduct.Quantity,
                .Stock = selectedProduct.Stock
            })
        End If

        ' Save updated cart
        Try
            Dim lines As New List(Of String)
            For Each item In cartItems
                lines.Add($"{item.Title}|{item.Description}|{Path.GetFileName(item.ImagePath)}|{item.Price.ToString(Globalization.CultureInfo.InvariantCulture)}|{item.Quantity}|{item.Stock}")
            Next
            File.WriteAllLines(cartPath, lines)
            MessageBox.Show("Added to cart", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving to cart: " & ex.Message)
        End Try
    End Sub

    'If the product information is the same as the prerequisites then the panel is created for the item and is shown along with their information
    Private Sub DisplayProductsByFilter(prerequisite As String)
        pnlProductList.Controls.Clear()
        Dim yOffset As Integer = 10

        For Each product In products
            If prerequisite = "" OrElse product.Brand = prerequisite OrElse product.ProductType = prerequisite Then
                Dim productPanel As New Panel With {
               .Width = pnlProductList.Width - 40,
               .Height = 180,
               .Left = 10,
               .Top = yOffset,
               .BorderStyle = BorderStyle.FixedSingle
           }

                ' Title
                Dim lblTitle As New Label With {
                    .Text = product.Title,
                    .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                    .Top = 10,
                    .Left = 120,
                    .AutoSize = True
                }

                ' Description
                Dim lblDesc As New Label With {
                    .Text = product.Description,
                    .Left = 120,
                    .Top = 40,
                    .Width = 600,
                    .Height = 90
                }
                Dim btnAddToCart As New Button With {
                    .Text = "Add to Cart",
                    .Top = 140,
                    .Left = 300,
                    .AutoSize = True,
                    .Tag = product
                }
                AddHandler btnAddToCart.Click, AddressOf AddToCart_Click

                ' Stock Status
                Dim lblStock As New Label With {.Left = 120, .Top = 140, .AutoSize = True}
                If product.Stock = 0 Then
                    btnAddToCart.Enabled = False
                    btnAddToCart.Text = "Out of Stock"
                End If

                ' Image
                Dim pic As New PictureBox With {
                .Image = Image.FromFile(product.ImagePath),
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .Width = 100,
                .Height = 100,
                .Left = 10,
                .Top = 20
                }

                ' Price
                Dim lblPrice As New Label With {
                    .Text = product.Price,
                    .Top = 130,
                    .Left = 10
                }


                ' Add controls to product panel
                productPanel.Controls.Add(lblTitle)
                productPanel.Controls.Add(lblDesc)
                productPanel.Controls.Add(lblStock)
                productPanel.Controls.Add(pic)
                productPanel.Controls.Add(lblPrice)
                productPanel.Controls.Add(btnAddToCart)

                ' Add to main scrollable panel
                pnlProductList.Controls.Add(productPanel)

                yOffset += productPanel.Height + 10

            End If
        Next
        'Checkout button
        Dim btnCheckout As New Button With {
           .Text = "Go To Checkout",
           .AutoSize = True,
           .Top = yOffset + 10,
           .Left = 250
       }

        'Back button
        Dim btnBack As New Button With {
        .Text = "Back",
        .AutoSize = True,
        .Top = yOffset + 10,
        .Left = 10
        }
        AddHandler btnCheckout.Click, AddressOf Checkout_Click
        AddHandler btnBack.Click, AddressOf Back_Click

        'Add to main scrollable panel
        pnlProductList.Controls.Add(btnCheckout)
        pnlProductList.Controls.Add(btnBack)
    End Sub

    'Display the products as they were originally
    Private Sub Back_Click(sender As Object, e As EventArgs)
        Dim answers As List(Of String) = LoadQuestionnaireAnswers(AppPaths.GoalsFile)
        Dim sortedProducts = products.OrderByDescending(Function(p) GetProductScore(p, answers)).ToList()
        DisplayProducts(sortedProducts)
    End Sub

    'Clear the file when the user wants to take the test again
    Private Sub ClearQuestionnaireFile()
        Dim filePath As String = AppPaths.GoalsFile

        If File.Exists(filePath) Then
            File.WriteAllText(filePath, "") ' Overwrites the file with an empty string
        End If
    End Sub

    'Inform the user about the company
    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        MessageBox.Show("We are a premium haircare company founded in 2025, specializing in sustainable and price-friendly products. We are dedicated to providing our customers with the best curly hair products as a comfortable price. ", "About Us")

    End Sub


    'FIlter the products by the prerequisite
    Private Sub SheaMoistureToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SheaMoistureToolStripMenuItem2.Click
        DisplayProductsByFilter("Shea Moisture")
    End Sub

    Private Sub OuaiToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OuaiToolStripMenuItem2.Click
        DisplayProductsByFilter("Ouai")

    End Sub

    Private Sub PATTERNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PATTERNToolStripMenuItem.Click
        DisplayProductsByFilter("PATTERN")

    End Sub

    Private Sub SkalaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkalaToolStripMenuItem.Click
        DisplayProductsByFilter("Skala")

    End Sub

    Private Sub CurlsmithToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CurlsmithToolStripMenuItem.Click
        DisplayProductsByFilter("CURLSMITH")

    End Sub

    Private Sub AllBrandsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllBrandsToolStripMenuItem.Click
        Dim answers As List(Of String) = LoadQuestionnaireAnswers(AppPaths.GoalsFile)
        Dim sortedProducts = products.OrderByDescending(Function(p) GetProductScore(p, answers)).ToList()
        DisplayProducts(sortedProducts)
    End Sub

    Private Sub ShampooToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShampooToolStripMenuItem.Click
        DisplayProductsByFilter("Shampoo")

    End Sub

    Private Sub ConditionerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConditionerToolStripMenuItem.Click
        DisplayProductsByFilter("Conditioner")

    End Sub

    Private Sub CreamToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreamToolStripMenuItem.Click
        DisplayProductsByFilter("Cream")

    End Sub

    Private Sub GelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GelToolStripMenuItem.Click
        DisplayProductsByFilter("Gel")

    End Sub

    Private Sub ScalpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScalpToolStripMenuItem.Click
        DisplayProductsByFilter("Scalp")

    End Sub

    Private Sub MasqueToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MasqueToolStripMenuItem1.Click
        DisplayProductsByFilter("Masque")

    End Sub

    Private Sub MousseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MousseToolStripMenuItem.Click
        DisplayProductsByFilter("Mousse")

    End Sub

    Private Sub DetanglerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetanglerToolStripMenuItem.Click
        DisplayProductsByFilter("Detangler")

    End Sub

    Private Sub HeatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeatToolStripMenuItem.Click
        DisplayProductsByFilter("Heat")

    End Sub

    'Clear the answers and open the questionnaire form
    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        ClearQuestionnaireFile()
        Me.Visible = False
        HalirzaQuestionnaire.Visible = True

    End Sub

End Class