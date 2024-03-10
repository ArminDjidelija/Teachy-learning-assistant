using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.API.Migrations
{
    /// <inheritdoc />
    public partial class prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipPitanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPitanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipSkole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipSkole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oblast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oblast_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProfesoriPredmeti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesoriPredmeti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesoriPredmeti_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfesoriPredmeti_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktivan = table.Column<bool>(type: "bit", nullable: false),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    UkupnoBodova = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AktivanDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Test_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Razred",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazredBroj = table.Column<int>(type: "int", nullable: false),
                    RazredKlasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipSkoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razred", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razred_TipSkole_TipSkoleId",
                        column: x => x.TipSkoleId,
                        principalTable: "TipSkole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Materijal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Putanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    OblastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materijal_Oblast_OblastId",
                        column: x => x.OblastId,
                        principalTable: "Oblast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Materijal_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojBodova = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OblastId = table.Column<int>(type: "int", nullable: false),
                    TipPitanjaId = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pitanje_Oblast_OblastId",
                        column: x => x.OblastId,
                        principalTable: "Oblast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pitanje_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pitanje_TipPitanja_TipPitanjaId",
                        column: x => x.TipPitanjaId,
                        principalTable: "TipPitanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RazrediProfesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    RazredId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RazrediProfesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RazrediProfesor_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RazrediProfesor_Razred_RazredId",
                        column: x => x.RazredId,
                        principalTable: "Razred",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazredId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Razred_RazredId",
                        column: x => x.RazredId,
                        principalTable: "Razred",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Odgovor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tacan = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Esejsko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PitanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odgovor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odgovor_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TestoviPitanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    PitanjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestoviPitanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestoviPitanja_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TestoviPitanja_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentiTestovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupnoBodova = table.Column<int>(type: "int", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zavrsen = table.Column<bool>(type: "bit", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiTestovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentiTestovi_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StudentiTestovi_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentiTestoviOdgovori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentiTestoviId = table.Column<int>(type: "int", nullable: false),
                    OdgovorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiTestoviOdgovori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentiTestoviOdgovori_Odgovor_OdgovorId",
                        column: x => x.OdgovorId,
                        principalTable: "Odgovor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StudentiTestoviOdgovori_StudentiTestovi_StudentiTestoviId",
                        column: x => x.StudentiTestoviId,
                        principalTable: "StudentiTestovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materijal_OblastId",
                table: "Materijal",
                column: "OblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Materijal_ProfesorId",
                table: "Materijal",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Oblast_PredmetId",
                table: "Oblast",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_PitanjeId",
                table: "Odgovor",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_OblastId",
                table: "Pitanje",
                column: "OblastId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_ProfesorId",
                table: "Pitanje",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_TipPitanjaId",
                table: "Pitanje",
                column: "TipPitanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoriPredmeti_PredmetId",
                table: "ProfesoriPredmeti",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoriPredmeti_ProfesorId",
                table: "ProfesoriPredmeti",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Razred_TipSkoleId",
                table: "Razred",
                column: "TipSkoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RazrediProfesor_ProfesorId",
                table: "RazrediProfesor",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_RazrediProfesor_RazredId",
                table: "RazrediProfesor",
                column: "RazredId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_RazredId",
                table: "Student",
                column: "RazredId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiTestovi_StudentId",
                table: "StudentiTestovi",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiTestovi_TestId",
                table: "StudentiTestovi",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiTestoviOdgovori_OdgovorId",
                table: "StudentiTestoviOdgovori",
                column: "OdgovorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiTestoviOdgovori_StudentiTestoviId",
                table: "StudentiTestoviOdgovori",
                column: "StudentiTestoviId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_PredmetId",
                table: "Test",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_ProfesorId",
                table: "Test",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestoviPitanja_PitanjeId",
                table: "TestoviPitanja",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_TestoviPitanja_TestId",
                table: "TestoviPitanja",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materijal");

            migrationBuilder.DropTable(
                name: "ProfesoriPredmeti");

            migrationBuilder.DropTable(
                name: "RazrediProfesor");

            migrationBuilder.DropTable(
                name: "StudentiTestoviOdgovori");

            migrationBuilder.DropTable(
                name: "TestoviPitanja");

            migrationBuilder.DropTable(
                name: "Odgovor");

            migrationBuilder.DropTable(
                name: "StudentiTestovi");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Oblast");

            migrationBuilder.DropTable(
                name: "TipPitanja");

            migrationBuilder.DropTable(
                name: "Razred");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "TipSkole");
        }
    }
}
