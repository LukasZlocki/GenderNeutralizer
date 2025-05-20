using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenderNeutralizer.App.Migrations
{
    /// <inheritdoc />
    public partial class extendModelCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCandidateToMeet",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCandidateToMeet",
                table: "Candidates");
        }
    }
}
