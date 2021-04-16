using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DigitalHive.Api.Migrations
{
    public partial class CommodityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommodityModels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Contract = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    NewTradeAction = table.Column<int>(type: "integer", nullable: false),
                    PnlDaily = table.Column<float>(type: "real", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Commodity = table.Column<string>(type: "text", nullable: true),
                    PnlYtd = table.Column<float>(type: "real", nullable: false),
                    PnlLtd = table.Column<float>(type: "real", nullable: false),
                    MddYtd = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommodityModels", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommodityModels");
        }
    }
}
