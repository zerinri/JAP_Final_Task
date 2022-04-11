using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NormativeApp.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseUnitMeasure = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitMeasure = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" },
                    { 4, "Brunch" },
                    { 5, "Snack" },
                    { 6, "Midnight snack" },
                    { 7, "Healty snack" },
                    { 8, "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedDate", "Name", "PurchasePrice", "PurchaseQuantity", "PurchaseUnitMeasure" },
                values: new object[,]
                {
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peppers", 15m, 5m, 0 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomato", 10m, 5m, 0 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meat", 20m, 1m, 0 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salt", 2m, 70m, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pepper", 4m, 10m, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cheese", 15m, 100m, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil", 7m, 1m, 2 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mushrooms", 25m, 20m, 1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flour", 10m, 1m, 0 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sugar", 3m, 80m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 241, 187, 7, 69, 22, 62, 76, 113, 127, 232, 247, 76, 167, 1, 13, 98, 116, 28, 168, 173, 32, 77, 217, 19, 198, 94, 8, 212, 144, 14, 237, 27, 33, 125, 201, 172, 166, 41, 177, 241, 125, 157, 217, 50, 15, 124, 106, 17, 3, 212, 118, 199, 15, 210, 242, 8, 53, 211, 246, 192, 200, 248, 15, 12 }, new byte[] { 139, 125, 191, 57, 195, 76, 73, 167, 70, 176, 54, 196, 211, 234, 177, 167, 49, 139, 117, 125, 103, 12, 106, 237, 223, 241, 122, 90, 253, 97, 76, 242, 39, 93, 110, 115, 211, 49, 143, 42, 69, 97, 44, 212, 85, 204, 199, 245, 141, 115, 214, 213, 1, 178, 151, 34, 64, 255, 8, 47, 77, 176, 194, 235, 201, 130, 173, 51, 21, 171, 221, 17, 230, 120, 141, 136, 93, 33, 184, 219, 128, 76, 173, 202, 221, 85, 116, 15, 143, 56, 236, 93, 16, 40, 90, 151, 22, 85, 71, 174, 0, 13, 80, 15, 5, 107, 216, 49, 53, 163, 253, 15, 105, 199, 3, 1, 216, 133, 237, 133, 36, 185, 155, 94, 72, 59, 112, 138 }, "admin" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 5, 1, "Lorem Ipsum", "Spagete5" },
                    { 34, 4, "Lorem Ipsum", "Makarone34" },
                    { 46, 4, "Lorem Ipsum", "Palacinke46" },
                    { 7, 5, "Lorem Ipsum", "Pizza7" },
                    { 10, 5, "Lorem Ipsum", "Ustipci10" },
                    { 12, 5, "Lorem Ipsum", "Spagete12" },
                    { 24, 5, "Lorem Ipsum", "Ustipci24" },
                    { 35, 5, "Lorem Ipsum", "Pizza35" },
                    { 43, 5, "Lorem Ipsum", "Pita43" },
                    { 50, 5, "Lorem Ipsum", "Pita50" },
                    { 1, 6, "Lorem Ipsum", "Pita1" },
                    { 2, 6, "Lorem Ipsum", "Musaka2" },
                    { 15, 6, "Lorem Ipsum", "Pita15" },
                    { 19, 6, "Lorem Ipsum", "Spagete19" },
                    { 20, 6, "Lorem Ipsum", "Makarone20" },
                    { 32, 6, "Lorem Ipsum", "Palacinke32" },
                    { 39, 6, "Lorem Ipsum", "Palacinke39" },
                    { 4, 7, "Lorem Ipsum", "Palacinke4" },
                    { 9, 7, "Lorem Ipsum", "Musaka9" },
                    { 17, 7, "Lorem Ipsum", "Ustipci17" },
                    { 29, 7, "Lorem Ipsum", "Pita29" },
                    { 38, 7, "Lorem Ipsum", "Ustipci38" },
                    { 33, 4, "Lorem Ipsum", "Spagete33" },
                    { 28, 4, "Lorem Ipsum", "Pizza28" },
                    { 21, 4, "Lorem Ipsum", "Pizza21" },
                    { 16, 4, "Lorem Ipsum", "Musaka16" },
                    { 8, 1, "Lorem Ipsum", "Pita8" },
                    { 11, 1, "Lorem Ipsum", "Palacinke11" },
                    { 14, 1, "Lorem Ipsum", "Pizza14" },
                    { 22, 1, "Lorem Ipsum", "Pita22" },
                    { 31, 1, "Lorem Ipsum", "Ustipci31" },
                    { 44, 1, "Lorem Ipsum", "Musaka44" },
                    { 3, 2, "Lorem Ipsum", "Ustipci3" },
                    { 18, 2, "Lorem Ipsum", "Palacinke18" },
                    { 25, 2, "Lorem Ipsum", "Palacinke25" },
                    { 27, 2, "Lorem Ipsum", "Makarone27" },
                    { 40, 7, "Lorem Ipsum", "Spagete40" },
                    { 45, 2, "Lorem Ipsum", "Ustipci45" },
                    { 48, 2, "Lorem Ipsum", "Makarone48" },
                    { 6, 3, "Lorem Ipsum", "Makarone6" },
                    { 23, 3, "Lorem Ipsum", "Musaka23" },
                    { 26, 3, "Lorem Ipsum", "Spagete26" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 30, 3, "Lorem Ipsum", "Musaka30" },
                    { 36, 3, "Lorem Ipsum", "Pita36" },
                    { 37, 3, "Lorem Ipsum", "Musaka37" },
                    { 41, 3, "Lorem Ipsum", "Makarone41" },
                    { 42, 3, "Lorem Ipsum", "Pizza42" },
                    { 13, 4, "Lorem Ipsum", "Makarone13" },
                    { 47, 2, "Lorem Ipsum", "Spagete47" },
                    { 49, 7, "Lorem Ipsum", "Pizza49" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 38, 6, 41m, 5, 3 },
                    { 175, 1, 79m, 43, 1 },
                    { 156, 9, 29m, 43, 0 },
                    { 147, 9, 16m, 43, 2 },
                    { 117, 4, 40m, 43, 0 },
                    { 90, 5, 24m, 43, 3 },
                    { 87, 6, 93m, 43, 3 },
                    { 46, 1, 57m, 43, 2 },
                    { 498, 2, 70m, 35, 1 },
                    { 465, 1, 98m, 35, 3 },
                    { 461, 1, 37m, 35, 1 },
                    { 429, 4, 51m, 35, 2 },
                    { 235, 4, 38m, 35, 3 },
                    { 200, 1, 91m, 35, 1 },
                    { 89, 3, 70m, 35, 1 },
                    { 70, 5, 71m, 35, 2 },
                    { 60, 2, 70m, 35, 3 },
                    { 474, 5, 36m, 24, 2 },
                    { 438, 2, 85m, 24, 3 },
                    { 355, 2, 33m, 24, 3 },
                    { 296, 9, 90m, 24, 0 },
                    { 240, 8, 64m, 24, 1 },
                    { 239, 3, 84m, 24, 1 },
                    { 153, 3, 96m, 24, 2 },
                    { 143, 1, 48m, 24, 1 },
                    { 490, 9, 17m, 12, 3 },
                    { 384, 8, 24m, 12, 0 },
                    { 373, 7, 37m, 12, 3 },
                    { 280, 9, 41m, 43, 1 },
                    { 220, 1, 43m, 12, 2 },
                    { 284, 6, 23m, 43, 0 },
                    { 486, 7, 86m, 43, 1 },
                    { 344, 1, 28m, 2, 2 },
                    { 329, 2, 18m, 2, 1 },
                    { 297, 9, 39m, 2, 3 },
                    { 290, 1, 99m, 2, 2 },
                    { 275, 5, 18m, 2, 3 },
                    { 263, 4, 15m, 2, 0 },
                    { 256, 4, 34m, 2, 1 },
                    { 201, 4, 28m, 2, 2 },
                    { 185, 1, 70m, 2, 1 },
                    { 167, 2, 63m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 160, 8, 25m, 2, 3 },
                    { 155, 8, 56m, 2, 1 },
                    { 97, 8, 85m, 2, 2 },
                    { 73, 4, 53m, 2, 3 },
                    { 58, 9, 89m, 2, 1 },
                    { 463, 3, 61m, 1, 1 },
                    { 457, 6, 92m, 1, 1 },
                    { 420, 6, 67m, 1, 1 },
                    { 386, 2, 41m, 1, 3 },
                    { 318, 2, 39m, 1, 1 },
                    { 310, 4, 16m, 1, 1 },
                    { 227, 2, 72m, 1, 2 },
                    { 195, 3, 86m, 1, 1 },
                    { 193, 1, 24m, 1, 1 },
                    { 120, 4, 52m, 1, 2 },
                    { 109, 7, 12m, 1, 1 },
                    { 98, 4, 19m, 1, 1 },
                    { 303, 7, 87m, 43, 2 },
                    { 162, 1, 74m, 12, 1 },
                    { 115, 6, 21m, 12, 1 },
                    { 75, 2, 72m, 12, 3 },
                    { 487, 3, 37m, 33, 2 },
                    { 462, 8, 28m, 33, 0 },
                    { 422, 2, 70m, 33, 1 },
                    { 188, 1, 59m, 33, 0 },
                    { 184, 9, 14m, 33, 2 },
                    { 172, 7, 29m, 33, 3 },
                    { 149, 2, 67m, 33, 2 },
                    { 48, 8, 45m, 33, 0 },
                    { 443, 5, 65m, 28, 3 },
                    { 391, 5, 88m, 28, 2 },
                    { 369, 4, 64m, 28, 3 },
                    { 307, 8, 55m, 28, 3 },
                    { 277, 4, 94m, 28, 1 },
                    { 161, 6, 28m, 28, 3 },
                    { 135, 6, 41m, 28, 3 },
                    { 111, 4, 63m, 28, 3 },
                    { 479, 8, 54m, 21, 2 },
                    { 473, 5, 71m, 21, 2 },
                    { 471, 5, 17m, 21, 2 },
                    { 451, 2, 46m, 21, 1 },
                    { 418, 5, 52m, 21, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 416, 6, 69m, 21, 1 },
                    { 389, 8, 92m, 21, 1 },
                    { 323, 7, 67m, 21, 3 },
                    { 292, 5, 76m, 21, 3 },
                    { 212, 2, 95m, 21, 3 },
                    { 209, 7, 10m, 21, 1 },
                    { 72, 1, 62m, 34, 0 },
                    { 80, 8, 52m, 34, 0 },
                    { 131, 5, 28m, 34, 0 },
                    { 250, 1, 48m, 34, 2 },
                    { 41, 4, 12m, 12, 1 },
                    { 439, 2, 50m, 10, 2 },
                    { 392, 7, 26m, 10, 1 },
                    { 306, 8, 86m, 10, 3 },
                    { 299, 6, 15m, 10, 2 },
                    { 267, 1, 28m, 10, 0 },
                    { 251, 8, 24m, 10, 0 },
                    { 216, 5, 94m, 10, 0 },
                    { 127, 2, 75m, 10, 2 },
                    { 478, 4, 82m, 7, 0 },
                    { 442, 6, 14m, 7, 3 },
                    { 441, 4, 55m, 7, 3 },
                    { 433, 3, 66m, 7, 0 },
                    { 348, 9, 67m, 2, 1 },
                    { 410, 9, 18m, 7, 1 },
                    { 325, 7, 31m, 7, 1 },
                    { 203, 6, 82m, 7, 1 },
                    { 494, 4, 69m, 46, 3 },
                    { 430, 7, 50m, 46, 2 },
                    { 259, 4, 74m, 46, 3 },
                    { 146, 3, 82m, 46, 3 },
                    { 103, 1, 55m, 46, 0 },
                    { 421, 8, 71m, 34, 3 },
                    { 403, 3, 31m, 34, 1 },
                    { 401, 6, 82m, 34, 3 },
                    { 278, 5, 94m, 34, 2 },
                    { 272, 1, 75m, 34, 1 },
                    { 255, 3, 73m, 34, 2 },
                    { 370, 2, 59m, 7, 0 },
                    { 183, 8, 45m, 21, 2 },
                    { 374, 3, 14m, 2, 0 },
                    { 488, 6, 84m, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 361, 4, 89m, 17, 3 },
                    { 333, 4, 83m, 17, 1 },
                    { 328, 3, 58m, 17, 1 },
                    { 321, 3, 61m, 17, 1 },
                    { 313, 7, 97m, 17, 0 },
                    { 264, 8, 70m, 17, 3 },
                    { 224, 1, 73m, 17, 1 },
                    { 128, 9, 84m, 17, 3 },
                    { 477, 2, 93m, 9, 1 },
                    { 399, 2, 14m, 9, 2 },
                    { 334, 9, 93m, 9, 1 },
                    { 271, 6, 98m, 9, 3 },
                    { 129, 6, 28m, 9, 3 },
                    { 119, 9, 82m, 9, 3 },
                    { 106, 6, 40m, 9, 0 },
                    { 66, 8, 87m, 9, 1 },
                    { 12, 6, 22m, 9, 1 },
                    { 7, 2, 76m, 9, 0 },
                    { 3, 5, 87m, 9, 0 },
                    { 492, 1, 20m, 4, 1 },
                    { 469, 1, 69m, 4, 0 },
                    { 413, 4, 94m, 4, 1 },
                    { 382, 1, 34m, 4, 0 },
                    { 379, 7, 86m, 4, 2 },
                    { 378, 3, 53m, 4, 0 },
                    { 335, 4, 85m, 4, 3 },
                    { 228, 2, 56m, 4, 1 },
                    { 426, 7, 84m, 17, 2 },
                    { 138, 1, 18m, 4, 3 },
                    { 467, 4, 87m, 17, 2 },
                    { 9, 8, 96m, 29, 1 },
                    { 468, 3, 17m, 49, 0 },
                    { 445, 9, 27m, 49, 3 },
                    { 435, 2, 96m, 49, 0 },
                    { 40, 2, 54m, 49, 0 },
                    { 21, 5, 11m, 49, 3 },
                    { 20, 9, 47m, 49, 2 },
                    { 454, 4, 71m, 40, 3 },
                    { 362, 9, 47m, 40, 3 },
                    { 326, 3, 28m, 40, 1 },
                    { 276, 7, 20m, 40, 3 },
                    { 230, 6, 33m, 40, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 219, 3, 14m, 40, 1 },
                    { 163, 5, 70m, 40, 0 },
                    { 459, 1, 48m, 38, 0 },
                    { 402, 5, 43m, 38, 1 },
                    { 381, 2, 11m, 38, 2 },
                    { 354, 7, 37m, 38, 0 },
                    { 225, 7, 54m, 38, 2 },
                    { 84, 7, 57m, 38, 3 },
                    { 37, 7, 45m, 38, 2 },
                    { 493, 6, 70m, 29, 2 },
                    { 446, 3, 53m, 29, 3 },
                    { 405, 1, 17m, 29, 0 },
                    { 265, 9, 43m, 29, 2 },
                    { 210, 1, 47m, 29, 3 },
                    { 140, 9, 10m, 29, 1 },
                    { 85, 9, 64m, 29, 1 },
                    { 484, 4, 30m, 17, 3 },
                    { 82, 6, 66m, 4, 2 },
                    { 71, 6, 22m, 4, 1 },
                    { 10, 6, 36m, 4, 3 },
                    { 238, 9, 43m, 20, 1 },
                    { 178, 3, 64m, 20, 1 },
                    { 34, 3, 77m, 20, 0 },
                    { 448, 3, 51m, 19, 3 },
                    { 411, 3, 76m, 19, 2 },
                    { 357, 9, 18m, 19, 1 },
                    { 311, 3, 16m, 19, 0 },
                    { 223, 3, 10m, 19, 1 },
                    { 190, 5, 21m, 19, 2 },
                    { 150, 2, 19m, 19, 0 },
                    { 49, 2, 30m, 19, 1 },
                    { 4, 2, 45m, 19, 0 },
                    { 499, 7, 52m, 15, 0 },
                    { 464, 8, 71m, 15, 3 },
                    { 453, 2, 64m, 15, 2 },
                    { 432, 7, 28m, 15, 3 },
                    { 407, 6, 14m, 15, 3 },
                    { 376, 2, 47m, 15, 1 },
                    { 352, 8, 29m, 15, 3 },
                    { 281, 2, 67m, 15, 1 },
                    { 266, 8, 85m, 15, 1 },
                    { 107, 9, 13m, 15, 0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 61, 1, 39m, 15, 1 },
                    { 51, 1, 37m, 15, 0 },
                    { 50, 9, 77m, 15, 0 },
                    { 14, 7, 88m, 15, 2 },
                    { 13, 8, 62m, 15, 3 },
                    { 327, 7, 47m, 20, 0 },
                    { 377, 8, 82m, 20, 1 },
                    { 388, 5, 73m, 20, 0 },
                    { 424, 9, 78m, 20, 3 },
                    { 483, 9, 38m, 39, 2 },
                    { 444, 2, 87m, 39, 0 },
                    { 366, 1, 54m, 39, 0 },
                    { 336, 6, 90m, 39, 1 },
                    { 295, 4, 20m, 39, 1 },
                    { 262, 9, 14m, 39, 1 },
                    { 254, 7, 29m, 39, 2 },
                    { 253, 7, 18m, 39, 1 },
                    { 249, 3, 16m, 39, 2 },
                    { 242, 1, 67m, 39, 1 },
                    { 93, 4, 12m, 39, 3 },
                    { 63, 9, 28m, 39, 3 },
                    { 437, 5, 17m, 32, 3 },
                    { 423, 6, 31m, 2, 3 },
                    { 397, 7, 35m, 32, 0 },
                    { 349, 9, 81m, 32, 2 },
                    { 312, 8, 55m, 32, 1 },
                    { 221, 4, 75m, 32, 0 },
                    { 217, 8, 67m, 32, 3 },
                    { 152, 1, 40m, 32, 0 },
                    { 118, 2, 24m, 32, 1 },
                    { 96, 8, 82m, 32, 2 },
                    { 42, 5, 46m, 32, 0 },
                    { 32, 3, 75m, 32, 2 },
                    { 30, 6, 75m, 32, 0 },
                    { 29, 2, 19m, 32, 0 },
                    { 11, 9, 13m, 32, 2 },
                    { 456, 5, 55m, 20, 0 },
                    { 364, 7, 34m, 32, 2 },
                    { 126, 8, 47m, 21, 0 },
                    { 43, 7, 80m, 21, 3 },
                    { 25, 8, 57m, 21, 1 },
                    { 383, 4, 18m, 18, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 356, 1, 17m, 18, 0 },
                    { 331, 8, 84m, 18, 0 },
                    { 314, 4, 32m, 18, 0 },
                    { 261, 8, 54m, 18, 0 },
                    { 137, 9, 12m, 18, 2 },
                    { 65, 7, 14m, 18, 0 },
                    { 496, 3, 55m, 3, 1 },
                    { 495, 3, 87m, 3, 0 },
                    { 353, 2, 19m, 3, 2 },
                    { 301, 4, 91m, 3, 2 },
                    { 243, 1, 13m, 3, 0 },
                    { 229, 2, 71m, 3, 3 },
                    { 222, 4, 19m, 3, 0 },
                    { 148, 2, 60m, 3, 2 },
                    { 142, 9, 68m, 3, 0 },
                    { 123, 2, 85m, 3, 1 },
                    { 79, 3, 44m, 3, 2 },
                    { 54, 5, 45m, 3, 1 },
                    { 53, 4, 94m, 3, 3 },
                    { 17, 1, 77m, 3, 2 },
                    { 480, 4, 15m, 44, 2 },
                    { 455, 5, 55m, 44, 0 },
                    { 449, 7, 25m, 44, 0 },
                    { 375, 4, 94m, 44, 2 },
                    { 319, 9, 14m, 44, 3 },
                    { 283, 7, 19m, 44, 0 },
                    { 408, 6, 46m, 18, 1 },
                    { 270, 9, 43m, 44, 3 },
                    { 415, 4, 64m, 18, 1 },
                    { 489, 4, 74m, 18, 1 },
                    { 108, 5, 24m, 45, 1 },
                    { 452, 1, 16m, 27, 1 },
                    { 414, 3, 98m, 27, 3 },
                    { 380, 5, 10m, 27, 1 },
                    { 350, 9, 65m, 27, 2 },
                    { 338, 4, 65m, 27, 0 },
                    { 294, 1, 16m, 27, 3 },
                    { 288, 5, 68m, 27, 1 },
                    { 234, 8, 17m, 27, 2 },
                    { 226, 1, 74m, 27, 0 },
                    { 165, 9, 57m, 27, 3 },
                    { 136, 1, 56m, 27, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 67, 9, 43m, 27, 1 },
                    { 27, 9, 14m, 27, 1 },
                    { 406, 7, 33m, 25, 0 },
                    { 342, 5, 93m, 25, 1 },
                    { 332, 5, 79m, 25, 1 },
                    { 315, 2, 94m, 25, 0 },
                    { 269, 2, 26m, 25, 1 },
                    { 247, 3, 10m, 25, 0 },
                    { 177, 4, 80m, 25, 3 },
                    { 157, 8, 47m, 25, 0 },
                    { 114, 2, 70m, 25, 3 },
                    { 113, 4, 39m, 25, 3 },
                    { 105, 6, 96m, 25, 0 },
                    { 100, 5, 57m, 25, 3 },
                    { 56, 1, 71m, 25, 2 },
                    { 431, 7, 26m, 18, 3 },
                    { 154, 6, 37m, 44, 1 },
                    { 133, 9, 87m, 44, 3 },
                    { 62, 6, 39m, 44, 3 },
                    { 396, 9, 91m, 11, 3 },
                    { 317, 4, 11m, 11, 1 },
                    { 215, 4, 78m, 11, 0 },
                    { 134, 9, 20m, 11, 1 },
                    { 94, 3, 37m, 11, 2 },
                    { 76, 1, 98m, 11, 1 },
                    { 18, 2, 36m, 11, 2 },
                    { 2, 6, 96m, 11, 0 },
                    { 470, 3, 69m, 8, 1 },
                    { 390, 7, 22m, 8, 0 },
                    { 337, 5, 85m, 8, 0 },
                    { 298, 5, 51m, 8, 0 },
                    { 180, 6, 51m, 8, 0 },
                    { 122, 3, 68m, 8, 3 },
                    { 102, 1, 28m, 8, 0 },
                    { 92, 1, 22m, 8, 0 },
                    { 86, 6, 51m, 8, 2 },
                    { 39, 1, 65m, 8, 3 },
                    { 33, 8, 90m, 8, 1 },
                    { 359, 5, 39m, 5, 3 },
                    { 330, 8, 86m, 5, 3 },
                    { 286, 5, 42m, 5, 1 },
                    { 218, 7, 19m, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 213, 2, 80m, 5, 0 },
                    { 187, 5, 36m, 5, 1 },
                    { 173, 7, 65m, 5, 1 },
                    { 74, 2, 80m, 5, 0 },
                    { 404, 9, 22m, 11, 2 },
                    { 491, 4, 48m, 11, 1 },
                    { 5, 2, 90m, 14, 0 },
                    { 244, 4, 54m, 14, 1 },
                    { 55, 5, 53m, 44, 2 },
                    { 28, 5, 63m, 44, 3 },
                    { 24, 2, 95m, 44, 3 },
                    { 482, 4, 94m, 31, 2 },
                    { 365, 6, 23m, 31, 0 },
                    { 351, 7, 98m, 31, 2 },
                    { 346, 5, 72m, 31, 3 },
                    { 305, 9, 98m, 31, 0 },
                    { 279, 4, 57m, 31, 2 },
                    { 233, 8, 44m, 31, 0 },
                    { 196, 7, 72m, 31, 0 },
                    { 168, 2, 14m, 31, 1 },
                    { 164, 9, 60m, 31, 0 },
                    { 112, 7, 14m, 45, 1 },
                    { 95, 5, 61m, 31, 0 },
                    { 372, 8, 41m, 22, 0 },
                    { 368, 4, 94m, 22, 0 },
                    { 340, 9, 75m, 22, 3 },
                    { 208, 8, 93m, 22, 3 },
                    { 176, 5, 45m, 22, 2 },
                    { 77, 5, 95m, 22, 3 },
                    { 59, 8, 70m, 22, 3 },
                    { 22, 6, 57m, 22, 3 },
                    { 358, 6, 26m, 14, 3 },
                    { 343, 1, 19m, 14, 2 },
                    { 302, 9, 63m, 14, 1 },
                    { 293, 1, 33m, 14, 2 },
                    { 258, 7, 52m, 14, 1 },
                    { 1, 3, 67m, 31, 3 },
                    { 125, 2, 21m, 45, 2 },
                    { 181, 6, 20m, 45, 3 },
                    { 192, 9, 51m, 45, 3 },
                    { 436, 1, 78m, 41, 0 },
                    { 412, 1, 92m, 41, 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 385, 3, 60m, 41, 2 },
                    { 282, 8, 18m, 41, 0 },
                    { 241, 9, 91m, 41, 1 },
                    { 207, 6, 31m, 41, 3 },
                    { 139, 5, 87m, 41, 3 },
                    { 88, 2, 81m, 41, 0 },
                    { 78, 4, 59m, 41, 3 },
                    { 26, 6, 99m, 41, 1 },
                    { 8, 1, 50m, 41, 3 },
                    { 434, 8, 86m, 37, 3 },
                    { 273, 9, 46m, 37, 3 },
                    { 232, 9, 37m, 37, 2 },
                    { 231, 4, 59m, 37, 3 },
                    { 205, 2, 29m, 37, 3 },
                    { 170, 4, 14m, 37, 0 },
                    { 130, 9, 38m, 37, 2 },
                    { 99, 7, 42m, 37, 3 },
                    { 83, 8, 27m, 37, 2 },
                    { 15, 1, 78m, 37, 1 },
                    { 347, 6, 24m, 36, 3 },
                    { 320, 4, 20m, 36, 2 },
                    { 237, 8, 19m, 36, 1 },
                    { 236, 6, 31m, 36, 1 },
                    { 211, 7, 14m, 36, 1 },
                    { 198, 2, 32m, 36, 2 },
                    { 460, 5, 50m, 41, 0 },
                    { 472, 8, 89m, 41, 3 },
                    { 16, 6, 60m, 42, 1 },
                    { 19, 1, 87m, 42, 0 },
                    { 409, 1, 56m, 16, 2 },
                    { 197, 1, 16m, 16, 1 },
                    { 151, 7, 26m, 16, 1 },
                    { 141, 8, 72m, 16, 0 },
                    { 132, 9, 89m, 16, 3 },
                    { 81, 1, 28m, 16, 0 },
                    { 57, 4, 46m, 16, 3 },
                    { 6, 1, 57m, 16, 2 },
                    { 500, 6, 95m, 13, 2 },
                    { 428, 7, 93m, 13, 3 },
                    { 400, 6, 77m, 13, 0 },
                    { 387, 8, 84m, 13, 0 },
                    { 300, 4, 83m, 13, 0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 169, 6, 61m, 36, 0 },
                    { 291, 5, 36m, 13, 1 },
                    { 124, 3, 15m, 13, 3 },
                    { 417, 1, 78m, 42, 1 },
                    { 395, 1, 52m, 42, 1 },
                    { 339, 3, 87m, 42, 1 },
                    { 246, 1, 37m, 42, 2 },
                    { 214, 2, 38m, 42, 3 },
                    { 206, 3, 26m, 42, 3 },
                    { 179, 1, 72m, 42, 1 },
                    { 110, 4, 48m, 42, 1 },
                    { 91, 3, 25m, 42, 3 },
                    { 69, 5, 38m, 42, 0 },
                    { 68, 6, 58m, 42, 2 },
                    { 52, 6, 76m, 42, 3 },
                    { 174, 4, 32m, 13, 2 },
                    { 475, 4, 92m, 49, 1 },
                    { 158, 4, 30m, 36, 3 },
                    { 363, 3, 22m, 30, 0 },
                    { 394, 4, 20m, 48, 2 },
                    { 341, 2, 18m, 48, 3 },
                    { 308, 5, 55m, 48, 0 },
                    { 268, 3, 79m, 48, 2 },
                    { 248, 8, 21m, 48, 3 },
                    { 145, 1, 17m, 48, 0 },
                    { 116, 7, 55m, 48, 0 },
                    { 104, 7, 31m, 48, 3 },
                    { 45, 2, 18m, 48, 3 },
                    { 458, 4, 81m, 47, 1 },
                    { 427, 4, 40m, 47, 2 },
                    { 398, 1, 27m, 47, 1 },
                    { 367, 2, 66m, 47, 1 },
                    { 287, 8, 40m, 47, 1 },
                    { 260, 9, 77m, 47, 2 },
                    { 257, 2, 68m, 47, 1 },
                    { 186, 3, 63m, 47, 3 },
                    { 159, 6, 13m, 47, 1 },
                    { 121, 9, 98m, 47, 2 },
                    { 23, 4, 54m, 47, 1 },
                    { 419, 9, 15m, 45, 1 },
                    { 345, 7, 23m, 45, 3 },
                    { 304, 9, 34m, 45, 0 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "IngredientId", "Quantity", "RecipeId", "UnitMeasure" },
                values: new object[,]
                {
                    { 252, 9, 88m, 45, 1 },
                    { 202, 4, 43m, 45, 0 },
                    { 199, 1, 80m, 45, 2 },
                    { 194, 3, 41m, 45, 2 },
                    { 476, 5, 51m, 48, 2 },
                    { 44, 3, 98m, 6, 1 },
                    { 171, 4, 72m, 6, 1 },
                    { 245, 4, 19m, 6, 3 },
                    { 309, 7, 96m, 30, 1 },
                    { 274, 1, 33m, 30, 2 },
                    { 204, 1, 97m, 30, 2 },
                    { 189, 5, 29m, 30, 3 },
                    { 166, 8, 76m, 30, 1 },
                    { 144, 4, 14m, 30, 2 },
                    { 481, 9, 34m, 26, 2 },
                    { 450, 8, 23m, 26, 1 },
                    { 440, 9, 32m, 26, 0 },
                    { 393, 5, 76m, 26, 1 },
                    { 371, 3, 58m, 26, 3 },
                    { 360, 2, 65m, 26, 3 },
                    { 322, 2, 16m, 26, 1 },
                    { 425, 6, 85m, 30, 3 },
                    { 182, 9, 98m, 26, 0 },
                    { 36, 3, 95m, 26, 0 },
                    { 35, 8, 51m, 26, 0 },
                    { 31, 9, 63m, 26, 3 },
                    { 447, 7, 25m, 23, 2 },
                    { 324, 6, 63m, 23, 2 },
                    { 316, 7, 20m, 23, 0 },
                    { 285, 2, 42m, 23, 0 },
                    { 191, 4, 59m, 23, 2 },
                    { 101, 6, 10m, 23, 0 },
                    { 64, 2, 79m, 23, 0 },
                    { 497, 7, 43m, 6, 3 },
                    { 466, 9, 20m, 6, 3 },
                    { 289, 9, 51m, 6, 2 },
                    { 47, 1, 97m, 26, 0 },
                    { 485, 4, 55m, 49, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            var s1 = @"CREATE PROCEDURE [dbo].[dbo_spCategory_GetRecipeByCategory]
            AS
            BEGIN SELECT Categories.Name as CategoryName,Recipes.Name as RecipeName,
            SUM(dbo.CalculateTotalCosts(RecipeIngredients.Quantity, Ingredients.PurchasePrice, Ingredients.PurchaseQuantity,Ingredients.PurchaseUnitMeasure, RecipeIngredients.UnitMeasure)) 
            AS TotalCost
            FROM Ingredients
            JOIN RecipeIngredients
            ON Ingredients.Id = RecipeIngredients.IngredientId
            join Recipes
            on Recipes.Id = RecipeIngredients.RecipeId
            join Categories
            on Categories.Id = Recipes.CategoryId
            GROUP BY Categories.Name,Recipes.Name
            ORDER by Categories.Name, TotalCost desc;
            END";

            var s2 = @"Create procedure [dbo].[dbo_spRecipeIngredient_GetRecipeWithIngredientCount]
            AS
            BEGIN
            SELECT count(RecipeIngredients.IngredientId) as TotalIngredients,Recipes.Name,RecipeId,
            SUM(dbo.CalculateTotalCosts(RecipeIngredients.Quantity, Ingredients.PurchasePrice, Ingredients.PurchaseQuantity,Ingredients.PurchaseUnitMeasure,RecipeIngredients.UnitMeasure)) 
            AS TotalCost
            FROM Ingredients
            JOIN RecipeIngredients
            ON Ingredients.Id = RecipeIngredients.IngredientId
            join Recipes
            on Recipes.Id = RecipeIngredients.RecipeId
            join Categories
            on Categories.Id = Recipes.CategoryId
            GROUP BY RecipeId, Recipes.Name
            ORDER by TotalCost desc;
            END";

            var s3 = @"Create PROCEDURE [dbo].[dbo_spRecipeIngredients_FilterIngredients](
            @minCount AS DECIMAL
            ,@maxCount AS DECIMAL
	        ,@unitMeasure AS INT)
            AS
            BEGIN
            SELECT Count(IngredientId) as UsageCount,Ingredients.Name FROM RecipeIngredients
            Inner Join Ingredients
            ON  IngredientId = Ingredients.id 
            GROUP BY Name,UnitMeasure
            Having Count(IngredientId) >= @minCount AND
	        Count(IngredientId) <= @maxCount AND
            UnitMeasure LIKE @unitMeasure  
            ORDER BY UsageCount DESC
            END";

            var s4 = @"CREATE FUNCTION [dbo].[CalculateTotalCosts]
            (
              @recipesIngredientQuantity decimal
            , @ingredientPurchasedPrice decimal
            , @ingredientPurchasedQuantity decimal
            , @ingredientUnit int
            , @recipesIngredientUnit int
            )
            RETURNS float
            AS
            BEGIN
            DECLARE @TotalCost float;
            SELECT @TotalCost = CASE
            WHEN @ingredientUnit = 1 and @recipesIngredientUnit = 1 or @ingredientUnit = 3 and @recipesIngredientUnit = 3 or @ingredientUnit = 1 and @recipesIngredientUnit = 3
            THEN
            (@recipesIngredientQuantity / 1000) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity / 1000)) 
            WHEN @recipesIngredientUnit = 1 OR @recipesIngredientUnit = 3 
            THEN
            (@recipesIngredientQuantity / 1000) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity)) 
            WHEN @ingredientUnit = 1 OR @ingredientUnit = 3 
            THEN
            (@recipesIngredientQuantity ) * (@ingredientPurchasedPrice / (@ingredientPurchasedQuantity / 1000)) 
            ELSE
            @recipesIngredientQuantity * (@ingredientPurchasedPrice / @ingredientPurchasedQuantity)
            END 
            RETURN @TotalCost
            END";

            migrationBuilder.Sql(s1);
            migrationBuilder.Sql(s2);
            migrationBuilder.Sql(s3);
            migrationBuilder.Sql(s4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
