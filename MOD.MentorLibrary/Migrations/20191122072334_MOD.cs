using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MOD.MentorLibrary.Migrations
{
    public partial class MOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDtls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(nullable: true),
                    trainerId = table.Column<string>(nullable: true),
                    skillId = table.Column<int>(nullable: false),
                    fees = table.Column<double>(nullable: false),
                    trainerFees = table.Column<double>(nullable: false),
                    commision = table.Column<double>(nullable: false),
                    skillName = table.Column<string>(nullable: true),
                    paymentStatus = table.Column<bool>(nullable: false),
                    trainingDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDtls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TOC = table.Column<string>(nullable: true),
                    Fees = table.Column<int>(nullable: false),
                    Prerequisites = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDtls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true),
                    progress = table.Column<int>(nullable: false),
                    commisionAmount = table.Column<double>(nullable: false),
                    rating = table.Column<int>(nullable: false),
                    avaRating = table.Column<double>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    timeSlot = table.Column<string>(nullable: true),
                    amountReceived = table.Column<double>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    userFirstName = table.Column<string>(nullable: true),
                    userLastName = table.Column<string>(nullable: true),
                    mentorId = table.Column<string>(nullable: true),
                    mentorFirstName = table.Column<string>(nullable: true),
                    mentorLastName = table.Column<string>(nullable: true),
                    skillId = table.Column<int>(nullable: false),
                    skillname = table.Column<string>(nullable: true),
                    accept = table.Column<bool>(nullable: false),
                    rejectNotify = table.Column<bool>(nullable: false),
                    trainingPaymentStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDtls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserMods",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    YearOfExperience = table.Column<int>(nullable: false),
                    TrainerTechnology = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ConfirmSignup = table.Column<bool>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    TrainerTimings = table.Column<string>(nullable: true),
                    RegCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDtls");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "TrainingDtls");

            migrationBuilder.DropTable(
                name: "UserMods");
        }
    }
}
