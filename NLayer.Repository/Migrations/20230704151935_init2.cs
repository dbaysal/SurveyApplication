using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextAreaSurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAreaSurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextAreaSurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextBoxSurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBoxSurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextBoxSurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpenEndedQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextAreaSurveyQuestionId = table.Column<int>(type: "int", nullable: true),
                    TextBoxSurveyQuestionId = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenEndedQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenEndedQuestionAnswers_TextAreaSurveyQuestions_TextAreaSurveyQuestionId",
                        column: x => x.TextAreaSurveyQuestionId,
                        principalTable: "TextAreaSurveyQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenEndedQuestionAnswers_TextBoxSurveyQuestions_TextBoxSurveyQuestionId",
                        column: x => x.TextBoxSurveyQuestionId,
                        principalTable: "TextBoxSurveyQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenEndedQuestionAnswers_TextAreaSurveyQuestionId",
                table: "OpenEndedQuestionAnswers",
                column: "TextAreaSurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenEndedQuestionAnswers_TextBoxSurveyQuestionId",
                table: "OpenEndedQuestionAnswers",
                column: "TextBoxSurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAreaSurveyQuestions_SurveyId",
                table: "TextAreaSurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_TextBoxSurveyQuestions_SurveyId",
                table: "TextBoxSurveyQuestions",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpenEndedQuestionAnswers");

            migrationBuilder.DropTable(
                name: "TextAreaSurveyQuestions");

            migrationBuilder.DropTable(
                name: "TextBoxSurveyQuestions");
        }
    }
}
