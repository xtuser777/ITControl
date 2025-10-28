using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Alias", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("05fe343e-1475-4674-a12e-ea4a74043d16"), "SEDUC", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4983), "Secretaria Municipal de Educação", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4984) },
                    { new Guid("10a50965-0a61-4ba7-b3a2-be1919009acf"), "GABINETE", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5028), "Gabinete do Prefeito", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5028) },
                    { new Guid("20fe6fd4-05a1-44fb-9a94-367550c964e1"), "SEMAM", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5017), "Secretaria Municipal de Agricultura e Meio ambiente", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5017) },
                    { new Guid("2571abe5-8488-422d-aad3-c7f20b7db357"), "SEMEL", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5010), "Secretaria Municipal de Esporte e Lazer", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5010) },
                    { new Guid("30bb193f-66e2-4c45-85ed-5db46b763f39"), "COINTER", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5023), "Controladoria Interna", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5024) },
                    { new Guid("3a5ea193-864c-41f6-9d55-89a986f39077"), "SEMAD", new DateTime(2025, 10, 28, 14, 17, 31, 174, DateTimeKind.Local).AddTicks(9068), "Secretaria Municipal de Administração", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4267) },
                    { new Guid("3cd11a67-ff2d-424a-966c-29c855a5d863"), "SECULT", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4990), "Secretaria Municipal de Cultura e Turismo", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4991) },
                    { new Guid("579cddb0-6d44-48ee-b54a-363a08ab674d"), "SEMAG", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4988), "Secretaria Municipal de Serviços Gerais", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4988) },
                    { new Guid("78c3284f-5225-4cd1-b680-7ae12c6afa0a"), "SEPLAD", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4981), "Secretaria Municipal de Planejamento e Desenvolvimento Econômico", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4981) },
                    { new Guid("7ca649f7-fccc-4ba4-90db-f7b49eaac988"), "SEMAJ", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5014), "Secretaria Municipal de Assuntos Jurídicos", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5015) },
                    { new Guid("da75ac7f-8d7f-4147-9e97-9f910005650f"), "SEACT", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5008), "Secretaria Municipal de Assistência Social e Cidadania", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5008) },
                    { new Guid("e8b4c5d7-0fd2-4f8c-a24f-f20979cedc45"), "SMSP", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5019), "Secretaria Municipal de Segurança Pública", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5019) },
                    { new Guid("ed13988f-84a9-408d-bb72-632d50d34712"), "SEGOV", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4799), "Secretaria Municipal de Governo", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4978) },
                    { new Guid("eed33f37-4e6f-4f96-9a11-9f64144560c2"), "SEMSA", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4986), "Secretaria Municipal de Saúde", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(4987) },
                    { new Guid("fb917715-8d22-4fb4-b6d8-171538618d3d"), "SOURB", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5021), "Secretaria Municipal de Infraestrutura", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5021) },
                    { new Guid("fd4d458e-760a-4d9a-ae12-bfc255b22118"), "SEFAZ", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5012), "Secretaria Municipal de Finanças", new DateTime(2025, 10, 28, 14, 17, 31, 176, DateTimeKind.Local).AddTicks(5012) }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04f3fe39-1598-4e81-8c35-7606daf43530"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2965), "systems", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2965) },
                    { new Guid("0a3997f6-274e-4c49-9ea2-fa598e0fc1c5"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2932), "users", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2942) },
                    { new Guid("19268b85-bbf1-47d2-9d72-4bdfc71a89cb"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2967), "appointments", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2968) },
                    { new Guid("20f7d0ca-bc5d-423c-a6f4-ab326a5403a5"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2972), "knowledge-bases", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2972) },
                    { new Guid("2bcccadc-c02d-45df-892b-351259968ed2"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2966), "calls", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2966) },
                    { new Guid("39f1327e-6e68-4e41-9295-2b45f3334d5c"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2975), "supplements", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2975) },
                    { new Guid("411b21d2-3a2f-4a7a-a316-a2313c18e1d5"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2952), "pages", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2952) },
                    { new Guid("5392f4d8-c983-4193-9430-35de843e2deb"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2978), "supplements-movements", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2978) },
                    { new Guid("5b5c4776-429f-4c56-a894-4d408522aa46"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2953), "positions", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2954) },
                    { new Guid("65a45d83-fdaf-466d-8bc8-a5b443573dc6"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2969), "treatments", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2969) },
                    { new Guid("79d96476-179f-4e45-aab3-a4a9dcfe7bc8"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2973), "profile", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2974) },
                    { new Guid("7d638e9a-8af9-4ff3-9cf6-c66a7d787831"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2956), "divisions", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2957) },
                    { new Guid("84c4c431-0cb8-4b55-bcd2-116a7007b974"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2958), "contracts", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2958) },
                    { new Guid("aa41a727-f167-4e12-a38e-3fc9c8c0977a"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2955), "departments", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2955) },
                    { new Guid("c3376238-86db-47f5-b09a-1212c0463093"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2950), "roles", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2950) },
                    { new Guid("f21af353-d1ba-4aab-a70e-8a353ecf1145"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2959), "equipments", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2960) },
                    { new Guid("fb13e4db-ebfc-4e39-b8e2-9e1c97fd81ea"), new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2970), "notifications", new DateTime(2025, 10, 28, 14, 17, 31, 189, DateTimeKind.Local).AddTicks(2971) }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("b642ff25-2b2c-4a40-a3a2-8e4882593cbb"), new DateTime(2025, 10, 28, 14, 17, 31, 190, DateTimeKind.Local).AddTicks(1594), "Analista de Sistemas", new DateTime(2025, 10, 28, 14, 17, 31, 190, DateTimeKind.Local).AddTicks(1598) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), true, new DateTime(2025, 10, 28, 14, 17, 31, 191, DateTimeKind.Local).AddTicks(1239), "Master", new DateTime(2025, 10, 28, 14, 17, 31, 191, DateTimeKind.Local).AddTicks(1242) });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AddressNumber", "CreatedAt", "Name", "Neighborhood", "Phone", "PostalCode", "StreetName", "UpdatedAt" },
                values: new object[] { new Guid("1243f9e1-9ba4-475b-9028-50d4f341c191"), "719", new DateTime(2025, 10, 28, 14, 17, 31, 199, DateTimeKind.Local).AddTicks(9049), "Paço Municipal", "Centro", "1832659200", "19600000", "Rua Marcílio Dias", new DateTime(2025, 10, 28, 14, 17, 31, 199, DateTimeKind.Local).AddTicks(9059) });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "CreatedAt", "DepartmentId", "Name", "UpdatedAt" },
                values: new object[] { new Guid("448ad46d-68b4-429e-a644-cc3065ee3d5a"), new DateTime(2025, 10, 28, 14, 17, 31, 179, DateTimeKind.Local).AddTicks(466), new Guid("3a5ea193-864c-41f6-9d55-89a986f39077"), "Divisão Municipal de Informática", new DateTime(2025, 10, 28, 14, 17, 31, 179, DateTimeKind.Local).AddTicks(475) });

            migrationBuilder.InsertData(
                table: "RolesPages",
                columns: new[] { "Id", "CreatedAt", "PageId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0189bbf2-4585-42e8-8cd9-aadf9c967707"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3957), new Guid("f21af353-d1ba-4aab-a70e-8a353ecf1145"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3958) },
                    { new Guid("07df0fe3-c6ba-49ad-b655-ad1b63b34030"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4120), new Guid("19268b85-bbf1-47d2-9d72-4bdfc71a89cb"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4121) },
                    { new Guid("15d73062-8880-4904-80e7-f40f110f6018"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3329), new Guid("c3376238-86db-47f5-b09a-1212c0463093"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3330) },
                    { new Guid("1b4410e2-81f3-444f-8fbd-7aa9b2c1c9f7"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4130), new Guid("20f7d0ca-bc5d-423c-a6f4-ab326a5403a5"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4130) },
                    { new Guid("2173cabf-446a-4b65-8a3b-401ab8215601"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4131), new Guid("79d96476-179f-4e45-aab3-a4a9dcfe7bc8"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4132) },
                    { new Guid("3bd7d914-5c73-4115-b616-7758cfb70fc7"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4123), new Guid("65a45d83-fdaf-466d-8bc8-a5b443573dc6"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4123) },
                    { new Guid("483f5ff1-3079-4b4d-a9ed-9e8beef890a0"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3333), new Guid("aa41a727-f167-4e12-a38e-3fc9c8c0977a"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3333) },
                    { new Guid("49fba7de-7f85-47db-8273-0b1a9b589051"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3332), new Guid("5b5c4776-429f-4c56-a894-4d408522aa46"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3332) },
                    { new Guid("68ce2ef1-e3af-4c4c-9b8a-306a2248671e"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3954), new Guid("84c4c431-0cb8-4b55-bcd2-116a7007b974"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3955) },
                    { new Guid("835563b8-1773-4543-84da-6530220fadd6"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4118), new Guid("2bcccadc-c02d-45df-892b-351259968ed2"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4119) },
                    { new Guid("8801bed9-767b-46f4-9f3a-928ee8d2c2fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4125), new Guid("fb13e4db-ebfc-4e39-b8e2-9e1c97fd81ea"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4125) },
                    { new Guid("a544666b-8a7e-47b3-bd1d-cf63870641ac"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3959), new Guid("04f3fe39-1598-4e81-8c35-7606daf43530"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3960) },
                    { new Guid("aaa5cf1c-311e-48b1-9be9-5856a116ff0f"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3331), new Guid("411b21d2-3a2f-4a7a-a316-a2313c18e1d5"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3331) },
                    { new Guid("b672ece3-4aa1-4411-9b3d-135c8508eeb7"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4134), new Guid("5392f4d8-c983-4193-9430-35de843e2deb"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4135) },
                    { new Guid("c68a8707-f39c-4146-a8db-5212137fe231"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4133), new Guid("39f1327e-6e68-4e41-9295-2b45f3334d5c"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(4133) },
                    { new Guid("e4479df2-5b6d-41d0-8125-e5f599b021d5"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3950), new Guid("7d638e9a-8af9-4ff3-9cf6-c66a7d787831"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3951) },
                    { new Guid("f15728d1-41d9-4469-ae7f-c54261baf939"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3317), new Guid("0a3997f6-274e-4c49-9ea2-fa598e0fc1c5"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new DateTime(2025, 10, 28, 14, 17, 31, 192, DateTimeKind.Local).AddTicks(3322) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "DepartmentId", "DivisionId", "Document", "Email", "Enrollment", "Name", "Password", "PositionId", "RoleId", "UnitId", "UpdatedAt", "Username" },
                values: new object[] { new Guid("26aace9e-4607-4c27-915d-943294083770"), true, new DateTime(2025, 10, 28, 14, 17, 31, 215, DateTimeKind.Local).AddTicks(8236), new Guid("3a5ea193-864c-41f6-9d55-89a986f39077"), new Guid("448ad46d-68b4-429e-a644-cc3065ee3d5a"), "02912383005", "contato@rancharia.sp.gov.br", 9999, "Administrador", "AIOyVbTxXU3LeyoXU2kd3cEoRe1BlVZota7IFlDfk69D0B1cxNPc4iMq+n6vmZEdJg==", new Guid("b642ff25-2b2c-4a40-a3a2-8e4882593cbb"), new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"), new Guid("1243f9e1-9ba4-475b-9028-50d4f341c191"), new DateTime(2025, 10, 28, 14, 17, 31, 215, DateTimeKind.Local).AddTicks(8255), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("05fe343e-1475-4674-a12e-ea4a74043d16"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("10a50965-0a61-4ba7-b3a2-be1919009acf"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("20fe6fd4-05a1-44fb-9a94-367550c964e1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2571abe5-8488-422d-aad3-c7f20b7db357"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("30bb193f-66e2-4c45-85ed-5db46b763f39"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3cd11a67-ff2d-424a-966c-29c855a5d863"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("579cddb0-6d44-48ee-b54a-363a08ab674d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("78c3284f-5225-4cd1-b680-7ae12c6afa0a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7ca649f7-fccc-4ba4-90db-f7b49eaac988"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("da75ac7f-8d7f-4147-9e97-9f910005650f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e8b4c5d7-0fd2-4f8c-a24f-f20979cedc45"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ed13988f-84a9-408d-bb72-632d50d34712"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("eed33f37-4e6f-4f96-9a11-9f64144560c2"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("fb917715-8d22-4fb4-b6d8-171538618d3d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("fd4d458e-760a-4d9a-ae12-bfc255b22118"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("0189bbf2-4585-42e8-8cd9-aadf9c967707"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("07df0fe3-c6ba-49ad-b655-ad1b63b34030"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("15d73062-8880-4904-80e7-f40f110f6018"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("1b4410e2-81f3-444f-8fbd-7aa9b2c1c9f7"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("2173cabf-446a-4b65-8a3b-401ab8215601"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("3bd7d914-5c73-4115-b616-7758cfb70fc7"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("483f5ff1-3079-4b4d-a9ed-9e8beef890a0"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("49fba7de-7f85-47db-8273-0b1a9b589051"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("68ce2ef1-e3af-4c4c-9b8a-306a2248671e"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("835563b8-1773-4543-84da-6530220fadd6"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("8801bed9-767b-46f4-9f3a-928ee8d2c2fb"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("a544666b-8a7e-47b3-bd1d-cf63870641ac"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("aaa5cf1c-311e-48b1-9be9-5856a116ff0f"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("b672ece3-4aa1-4411-9b3d-135c8508eeb7"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("c68a8707-f39c-4146-a8db-5212137fe231"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("e4479df2-5b6d-41d0-8125-e5f599b021d5"));

            migrationBuilder.DeleteData(
                table: "RolesPages",
                keyColumn: "Id",
                keyValue: new Guid("f15728d1-41d9-4469-ae7f-c54261baf939"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26aace9e-4607-4c27-915d-943294083770"));

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: new Guid("448ad46d-68b4-429e-a644-cc3065ee3d5a"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("04f3fe39-1598-4e81-8c35-7606daf43530"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("0a3997f6-274e-4c49-9ea2-fa598e0fc1c5"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("19268b85-bbf1-47d2-9d72-4bdfc71a89cb"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("20f7d0ca-bc5d-423c-a6f4-ab326a5403a5"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("2bcccadc-c02d-45df-892b-351259968ed2"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("39f1327e-6e68-4e41-9295-2b45f3334d5c"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("411b21d2-3a2f-4a7a-a316-a2313c18e1d5"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("5392f4d8-c983-4193-9430-35de843e2deb"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("5b5c4776-429f-4c56-a894-4d408522aa46"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("65a45d83-fdaf-466d-8bc8-a5b443573dc6"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("79d96476-179f-4e45-aab3-a4a9dcfe7bc8"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("7d638e9a-8af9-4ff3-9cf6-c66a7d787831"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("84c4c431-0cb8-4b55-bcd2-116a7007b974"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("aa41a727-f167-4e12-a38e-3fc9c8c0977a"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("c3376238-86db-47f5-b09a-1212c0463093"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("f21af353-d1ba-4aab-a70e-8a353ecf1145"));

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: new Guid("fb13e4db-ebfc-4e39-b8e2-9e1c97fd81ea"));

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("b642ff25-2b2c-4a40-a3a2-8e4882593cbb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("94d54119-ce7c-42a5-866a-0c9ebe7077fb"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("1243f9e1-9ba4-475b-9028-50d4f341c191"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3a5ea193-864c-41f6-9d55-89a986f39077"));
        }
    }
}
