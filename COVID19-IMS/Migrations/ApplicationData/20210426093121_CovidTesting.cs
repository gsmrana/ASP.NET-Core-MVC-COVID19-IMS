using Microsoft.EntityFrameworkCore.Migrations;

namespace COVID19IMS.Migrations.ApplicationData
{
    public partial class CovidTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CovidTestings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentBoothNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidTestings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidTestings");
        }
    }
}
