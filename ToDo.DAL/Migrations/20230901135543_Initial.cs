using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Completed", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "delectus aut autem", 1 },
                    { 2, 0, "quis ut nam facilis et officia qui", 1 },
                    { 3, 0, "fugiat veniam minus", 1 },
                    { 4, 1, "et porro tempora", 1 },
                    { 5, 0, "laboriosam mollitia et enim quasi adipisci quia provident illum", 1 },
                    { 6, 0, "qui ullam ratione quibusdam voluptatem quia omnis", 1 },
                    { 7, 0, "illo expedita consequatur quia in", 1 },
                    { 8, 1, "quo adipisci enim quam ut ab", 1 },
                    { 9, 0, "molestiae perspiciatis ipsa", 1 },
                    { 10, 1, "illo est ratione doloremque quia maiores aut", 1 },
                    { 11, 1, "vero rerum temporibus dolor", 1 },
                    { 12, 1, "ipsa repellendus fugit nisi", 1 },
                    { 13, 0, "et doloremque nulla", 1 },
                    { 14, 1, "repellendus sunt dolores architecto voluptatum", 1 },
                    { 15, 1, "ab voluptatum amet voluptas", 1 },
                    { 16, 1, "accusamus eos facilis sint et aut voluptatem", 1 },
                    { 17, 1, "quo laboriosam deleniti aut qui", 1 },
                    { 18, 0, "dolorum est consequatur ea mollitia in culpa", 1 },
                    { 19, 1, "molestiae ipsa aut voluptatibus pariatur dolor nihil", 1 },
                    { 20, 1, "ullam nobis libero sapiente ad optio sint", 1 },
                    { 21, 0, "suscipit repellat esse quibusdam voluptatem incidunt", 2 },
                    { 22, 1, "distinctio vitae autem nihil ut molestias quo", 2 },
                    { 23, 0, "et itaque necessitatibus maxime molestiae qui quas velit", 2 },
                    { 24, 0, "adipisci non ad dicta qui amet quaerat doloribus ea", 2 },
                    { 25, 1, "voluptas quo tenetur perspiciatis explicabo natus", 2 },
                    { 26, 1, "aliquam aut quasi", 2 },
                    { 27, 1, "veritatis pariatur delectus", 2 },
                    { 28, 0, "nesciunt totam sit blanditiis sit", 2 },
                    { 29, 0, "laborum aut in quam", 2 },
                    { 30, 1, "nemo perspiciatis repellat ut dolor libero commodi blanditiis omnis", 2 },
                    { 31, 0, "repudiandae totam in est sint facere fuga", 2 },
                    { 32, 0, "earum doloribus ea doloremque quis", 2 },
                    { 33, 0, "sint sit aut vero", 2 },
                    { 34, 0, "porro aut necessitatibus eaque distinctio", 2 },
                    { 35, 1, "repellendus veritatis molestias dicta incidunt", 2 },
                    { 36, 1, "excepturi deleniti adipisci voluptatem et neque optio illum ad", 2 },
                    { 37, 0, "sunt cum tempora", 2 },
                    { 38, 0, "totam quia non", 2 },
                    { 39, 0, "doloremque quibusdam asperiores libero corrupti illum qui omnis", 2 },
                    { 40, 1, "totam atque quo nesciunt", 2 },
                    { 41, 0, "aliquid amet impedit consequatur aspernatur placeat eaque fugiat suscipit", 3 },
                    { 42, 0, "rerum perferendis error quia ut eveniet", 3 },
                    { 43, 1, "tempore ut sint quis recusandae", 3 },
                    { 44, 1, "cum debitis quis accusamus doloremque ipsa natus sapiente omnis", 3 },
                    { 45, 0, "velit soluta adipisci molestias reiciendis harum", 3 },
                    { 46, 0, "vel voluptatem repellat nihil placeat corporis", 3 },
                    { 47, 0, "nam qui rerum fugiat accusamus", 3 },
                    { 48, 0, "sit reprehenderit omnis quia", 3 },
                    { 49, 0, "ut necessitatibus aut maiores debitis officia blanditiis velit et", 3 },
                    { 50, 1, "cupiditate necessitatibus ullam aut quis dolor voluptate", 3 },
                    { 51, 0, "distinctio exercitationem ab doloribus", 3 },
                    { 52, 0, "nesciunt dolorum quis recusandae ad pariatur ratione", 3 },
                    { 53, 0, "qui labore est occaecati recusandae aliquid quam", 3 },
                    { 54, 1, "quis et est ut voluptate quam dolor", 3 },
                    { 55, 1, "voluptatum omnis minima qui occaecati provident nulla voluptatem ratione", 3 },
                    { 56, 1, "deleniti ea temporibus enim", 3 },
                    { 57, 0, "pariatur et magnam ea doloribus similique voluptatem rerum quia", 3 },
                    { 58, 0, "est dicta totam qui explicabo doloribus qui dignissimos", 3 },
                    { 59, 0, "perspiciatis velit id laborum placeat iusto et aliquam odio", 3 },
                    { 60, 1, "et sequi qui architecto ut adipisci", 3 },
                    { 61, 1, "odit optio omnis qui sunt", 4 },
                    { 62, 0, "et placeat et tempore aspernatur sint numquam", 4 },
                    { 63, 1, "doloremque aut dolores quidem fuga qui nulla", 4 },
                    { 64, 0, "voluptas consequatur qui ut quia magnam nemo esse", 4 },
                    { 65, 0, "fugiat pariatur ratione ut asperiores necessitatibus magni", 4 },
                    { 66, 0, "rerum eum molestias autem voluptatum sit optio", 4 },
                    { 67, 0, "quia voluptatibus voluptatem quos similique maiores repellat", 4 },
                    { 68, 0, "aut id perspiciatis voluptatem iusto", 4 },
                    { 69, 0, "doloribus sint dolorum ab adipisci itaque dignissimos aliquam suscipit", 4 },
                    { 70, 0, "ut sequi accusantium et mollitia delectus sunt", 4 },
                    { 71, 0, "aut velit saepe ullam", 4 },
                    { 72, 0, "praesentium facilis facere quis harum voluptatibus voluptatem eum", 4 },
                    { 73, 1, "sint amet quia totam corporis qui exercitationem commodi", 4 },
                    { 74, 0, "expedita tempore nobis eveniet laborum maiores", 4 },
                    { 75, 0, "occaecati adipisci est possimus totam", 4 },
                    { 76, 1, "sequi dolorem sed", 4 },
                    { 77, 0, "maiores aut nesciunt delectus exercitationem vel assumenda eligendi at", 4 },
                    { 78, 0, "reiciendis est magnam amet nemo iste recusandae impedit quaerat", 4 },
                    { 79, 1, "eum ipsa maxime ut", 4 },
                    { 80, 1, "tempore molestias dolores rerum sequi voluptates ipsum consequatur", 4 },
                    { 81, 1, "suscipit qui totam", 5 },
                    { 82, 0, "voluptates eum voluptas et dicta", 5 },
                    { 83, 1, "quidem at rerum quis ex aut sit quam", 5 },
                    { 84, 0, "sunt veritatis ut voluptate", 5 },
                    { 85, 1, "et quia ad iste a", 5 },
                    { 86, 1, "incidunt ut saepe autem", 5 },
                    { 87, 1, "laudantium quae eligendi consequatur quia et vero autem", 5 },
                    { 88, 0, "vitae aut excepturi laboriosam sint aliquam et et accusantium", 5 },
                    { 89, 1, "sequi ut omnis et", 5 },
                    { 90, 1, "molestiae nisi accusantium tenetur dolorem et", 5 },
                    { 91, 1, "nulla quis consequatur saepe qui id expedita", 5 },
                    { 92, 1, "in omnis laboriosam", 5 },
                    { 93, 1, "odio iure consequatur molestiae quibusdam necessitatibus quia sint", 5 },
                    { 94, 0, "facilis modi saepe mollitia", 5 },
                    { 95, 1, "vel nihil et molestiae iusto assumenda nemo quo ut", 5 },
                    { 96, 0, "nobis suscipit ducimus enim asperiores voluptas", 5 },
                    { 97, 0, "dolorum laboriosam eos qui iure aliquam", 5 },
                    { 98, 1, "debitis accusantium ut quo facilis nihil quis sapiente necessitatibus", 5 },
                    { 99, 0, "neque voluptates ratione", 5 },
                    { 100, 0, "excepturi a et neque qui expedita vel voluptate", 5 },
                    { 101, 0, "explicabo enim cumque porro aperiam occaecati minima", 6 },
                    { 102, 0, "sed ab consequatur", 6 },
                    { 103, 0, "non sunt delectus illo nulla tenetur enim omnis", 6 },
                    { 104, 0, "excepturi non laudantium quo", 6 },
                    { 105, 1, "totam quia dolorem et illum repellat voluptas optio", 6 },
                    { 106, 1, "ad illo quis voluptatem temporibus", 6 },
                    { 107, 0, "praesentium facilis omnis laudantium fugit ad iusto nihil nesciunt", 6 },
                    { 108, 1, "a eos eaque nihil et exercitationem incidunt delectus", 6 },
                    { 109, 1, "autem temporibus harum quisquam in culpa", 6 },
                    { 110, 1, "aut aut ea corporis", 6 },
                    { 111, 0, "magni accusantium labore et id quis provident", 6 },
                    { 112, 0, "consectetur impedit quisquam qui deserunt non rerum consequuntur eius", 6 },
                    { 113, 0, "quia atque aliquam sunt impedit voluptatum rerum assumenda nisi", 6 },
                    { 114, 0, "cupiditate quos possimus corporis quisquam exercitationem beatae", 6 },
                    { 115, 0, "sed et ea eum", 6 },
                    { 116, 1, "ipsa dolores vel facilis ut", 6 },
                    { 117, 0, "sequi quae est et qui qui eveniet asperiores", 6 },
                    { 118, 0, "quia modi consequatur vero fugiat", 6 },
                    { 119, 0, "corporis ducimus ea perspiciatis iste", 6 },
                    { 120, 0, "dolorem laboriosam vel voluptas et aliquam quasi", 6 },
                    { 121, 1, "inventore aut nihil minima laudantium hic qui omnis", 7 },
                    { 122, 1, "provident aut nobis culpa", 7 },
                    { 123, 0, "esse et quis iste est earum aut impedit", 7 },
                    { 124, 0, "qui consectetur id", 7 },
                    { 125, 0, "aut quasi autem iste tempore illum possimus", 7 },
                    { 126, 1, "ut asperiores perspiciatis veniam ipsum rerum saepe", 7 },
                    { 127, 1, "voluptatem libero consectetur rerum ut", 7 },
                    { 128, 0, "eius omnis est qui voluptatem autem", 7 },
                    { 129, 0, "rerum culpa quis harum", 7 },
                    { 130, 1, "nulla aliquid eveniet harum laborum libero alias ut unde", 7 },
                    { 131, 0, "qui ea incidunt quis", 7 },
                    { 132, 1, "qui molestiae voluptatibus velit iure harum quisquam", 7 },
                    { 133, 1, "et labore eos enim rerum consequatur sunt", 7 },
                    { 134, 0, "molestiae doloribus et laborum quod ea", 7 },
                    { 135, 0, "facere ipsa nam eum voluptates reiciendis vero qui", 7 },
                    { 136, 0, "asperiores illo tempora fuga sed ut quasi adipisci", 7 },
                    { 137, 0, "qui sit non", 7 },
                    { 138, 1, "placeat minima consequatur rem qui ut", 7 },
                    { 139, 0, "consequatur doloribus id possimus voluptas a voluptatem", 7 },
                    { 140, 1, "aut consectetur in blanditiis deserunt quia sed laboriosam", 7 },
                    { 141, 1, "explicabo consectetur debitis voluptates quas quae culpa rerum non", 8 },
                    { 142, 1, "maiores accusantium architecto necessitatibus reiciendis ea aut", 8 },
                    { 143, 0, "eum non recusandae cupiditate animi", 8 },
                    { 144, 0, "ut eum exercitationem sint", 8 },
                    { 145, 0, "beatae qui ullam incidunt voluptatem non nisi aliquam", 8 },
                    { 146, 1, "molestiae suscipit ratione nihil odio libero impedit vero totam", 8 },
                    { 147, 1, "eum itaque quod reprehenderit et facilis dolor autem ut", 8 },
                    { 148, 0, "esse quas et quo quasi exercitationem", 8 },
                    { 149, 0, "animi voluptas quod perferendis est", 8 },
                    { 150, 0, "eos amet tempore laudantium fugit a", 8 },
                    { 151, 1, "accusamus adipisci dicta qui quo ea explicabo sed vero", 8 },
                    { 152, 0, "odit eligendi recusandae doloremque cumque non", 8 },
                    { 153, 0, "ea aperiam consequatur qui repellat eos", 8 },
                    { 154, 1, "rerum non ex sapiente", 8 },
                    { 155, 1, "voluptatem nobis consequatur et assumenda magnam", 8 },
                    { 156, 1, "nam quia quia nulla repellat assumenda quibusdam sit nobis", 8 },
                    { 157, 1, "dolorem veniam quisquam deserunt repellendus", 8 },
                    { 158, 1, "debitis vitae delectus et harum accusamus aut deleniti a", 8 },
                    { 159, 1, "debitis adipisci quibusdam aliquam sed dolore ea praesentium nobis", 8 },
                    { 160, 0, "et praesentium aliquam est", 8 },
                    { 161, 1, "ex hic consequuntur earum omnis alias ut occaecati culpa", 9 },
                    { 162, 1, "omnis laboriosam molestias animi sunt dolore", 9 },
                    { 163, 0, "natus corrupti maxime laudantium et voluptatem laboriosam odit", 9 },
                    { 164, 0, "reprehenderit quos aut aut consequatur est sed", 9 },
                    { 165, 0, "fugiat perferendis sed aut quidem", 9 },
                    { 166, 0, "quos quo possimus suscipit minima ut", 9 },
                    { 167, 0, "et quis minus quo a asperiores molestiae", 9 },
                    { 168, 0, "recusandae quia qui sunt libero", 9 },
                    { 169, 1, "ea odio perferendis officiis", 9 },
                    { 170, 0, "quisquam aliquam quia doloribus aut", 9 },
                    { 171, 1, "fugiat aut voluptatibus corrupti deleniti velit iste odio", 9 },
                    { 172, 0, "et provident amet rerum consectetur et voluptatum", 9 },
                    { 173, 0, "harum ad aperiam quis", 9 },
                    { 174, 0, "similique aut quo", 9 },
                    { 175, 1, "laudantium eius officia perferendis provident perspiciatis asperiores", 9 },
                    { 176, 0, "magni soluta corrupti ut maiores rem quidem", 9 },
                    { 177, 0, "et placeat temporibus voluptas est tempora quos quibusdam", 9 },
                    { 178, 1, "nesciunt itaque commodi tempore", 9 },
                    { 179, 1, "omnis consequuntur cupiditate impedit itaque ipsam quo", 9 },
                    { 180, 1, "debitis nisi et dolorem repellat et", 9 },
                    { 181, 0, "ut cupiditate sequi aliquam fuga maiores", 10 },
                    { 182, 1, "inventore saepe cumque et aut illum enim", 10 },
                    { 183, 1, "omnis nulla eum aliquam distinctio", 10 },
                    { 184, 0, "molestias modi perferendis perspiciatis", 10 },
                    { 185, 0, "voluptates dignissimos sed doloribus animi quaerat aut", 10 },
                    { 186, 0, "explicabo odio est et", 10 },
                    { 187, 0, "consequuntur animi possimus", 10 },
                    { 188, 1, "vel non beatae est", 10 },
                    { 189, 1, "culpa eius et voluptatem et", 10 },
                    { 190, 1, "accusamus sint iusto et voluptatem exercitationem", 10 },
                    { 191, 1, "temporibus atque distinctio omnis eius impedit tempore molestias pariatur", 10 },
                    { 192, 0, "ut quas possimus exercitationem sint voluptates", 10 },
                    { 193, 1, "rerum debitis voluptatem qui eveniet tempora distinctio a", 10 },
                    { 194, 0, "sed ut vero sit molestiae", 10 },
                    { 195, 1, "rerum ex veniam mollitia voluptatibus pariatur", 10 },
                    { 196, 1, "consequuntur aut ut fugit similique", 10 },
                    { 197, 1, "dignissimos quo nobis earum saepe", 10 },
                    { 198, 1, "quis eius est sint explicabo", 10 },
                    { 199, 1, "numquam repellendus a magnam", 10 },
                    { 200, 0, "ipsam aperiam voluptates qui", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
