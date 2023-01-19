using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeCalculator.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GCalculator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentRegno = table.Column<int>(name: "Student_Regno", type: "int", nullable: false),
                    StudentName = table.Column<string>(name: "Student_Name", type: "nvarchar(max)", nullable: false),
                    StudentDept = table.Column<string>(name: "Student_Dept", type: "nvarchar(max)", nullable: false),
                    Subject1Mark = table.Column<int>(name: "Subject1_Mark", type: "int", nullable: false),
                    Subject2Mark = table.Column<int>(name: "Subject2_Mark", type: "int", nullable: false),
                    Subject3Mark = table.Column<int>(name: "Subject3_Mark", type: "int", nullable: false),
                    TotalMark = table.Column<int>(name: "Total_Mark", type: "int", nullable: false),
                    AverageMark = table.Column<int>(name: "Average_Mark", type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GCalculator", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GCalculator");
        }
    }
}
