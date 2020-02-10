namespace FinalCapstone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalCapstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalCapstone.Models.ApplicationDbContext context)
        {
        //context.Meetings.AddOrUpdate(x => x.OrganizationId,
        //new Models.Organization()
        //{
        //    OrganizationId = 1,
        //    Name = "StreetLife Communities",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "As created equals, we provide and restore respect, hope and place in the community by providing access to resources to the under-served of Milwaukee one life at a time, and inspire and train others to do the same."
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 2,
        //    Name = "Street Angels",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "Street Angels Milwaukee Outreach is a nonprofit volunteer-based organization that reaches out into the community three nights a week, 156 days a year."
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 3,
        //    Name = "Hunger Task Force",
        //    City = "West Allis",
        //    State = "WI",
        //    Bio = "We work to prevent hunger and malnutrition by providing food to people in need today and by promoting social policies to achieve a hunger free community tomorrow."
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 4,
        //    Name = "Community Advocates",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "We provide individuals & families with advocacy & services to meet their basic needs so they may live in dignity. "
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 5,
        //    Name = "United Way",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "We provide individuals & families with advocacy & services to meet their basic needs so they may live in dignity. "
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 6,
        //    Name = "VetsNet",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "We provide individuals & families with advocacy & services to meet their basic needs so they may live in dignity. "
        //},
        //new Models.Organization()
        //{
        //    OrganizationId = 7,
        //    Name = "Freidens Community Ministries",
        //    City = "Milwaukee",
        //    State = "WI",
        //    Bio = "We provide individuals & families with advocacy & services to meet their basic needs so they may live in dignity. "
        //}
        //);
            //context.Teams.AddOrUpdate(x => x.TeamId,
            //    new Models.Team(){ TeamId = 1,Name = "North Side", OrganizationId = 1 },
            //    new Models.Team(){ TeamId = 2, Name = "South Side", OrganizationId = 1 },
            //    new Models.Team(){ TeamId = 3, Name = "East Side", OrganizationId = 1 },
            //    new Models.Team(){ TeamId = 4, Name = "West Side", OrganizationId = 1 },
            //    new Models.Team(){ TeamId = 5, Name = "All Sides", OrganizationId = 1 },
            //    new Models.Team(){ TeamId = 6, Name = "Blue Team", OrganizationId = 2 },
            //    new Models.Team(){ TeamId = 8, Name = "Yellow Team", OrganizationId = 2 },
            //    new Models.Team(){ TeamId = 9, Name = "Red Team", OrganizationId = 2 },
            //    new Models.Team(){ TeamId = 10, Name = "Orange Team", OrganizationId = 2 },
            //    new Models.Team(){ TeamId = 11, Name = "Administrative Team", OrganizationId = 3 },
            //    new Models.Team(){ TeamId = 12, Name = "Saturday Team", OrganizationId = 3 },
            //    new Models.Team(){ TeamId = 13, Name = "Wednesday Team", OrganizationId = 3 },
            //    new Models.Team(){ TeamId = 14, Name = "Monday Team", OrganizationId = 3 },
            //    new Models.Team(){ TeamId = 15, Name = "Team Afternoon", OrganizationId = 4 },
            //    new Models.Team(){ TeamId = 16, Name = "Team Day", OrganizationId = 4 },
            //    new Models.Team(){ TeamId = 17, Name = "Team Night", OrganizationId = 4 },
            //    new Models.Team(){ TeamId = 18, Name = "Team Morning", OrganizationId = 4 },
            //    new Models.Team(){ TeamId = 19, Name = "Team Delta", OrganizationId = 5 },
            //    new Models.Team(){ TeamId = 20, Name = "Team Foxtrot", OrganizationId = 5 },
            //    new Models.Team(){ TeamId = 21, Name = "Team Tango", OrganizationId = 5 },
            //    new Models.Team(){ TeamId = 22, Name = "Team Sierra", OrganizationId = 5 },
            //    new Models.Team(){ TeamId = 23, Name = "Team Hotel", OrganizationId = 5 },
            //    new Models.Team(){ TeamId = 24, Name = "Echo Team", OrganizationId = 6 },
            //    new Models.Team(){ TeamId = 25, Name = "Quebec Team", OrganizationId = 6 },
            //    new Models.Team(){ TeamId = 26, Name = "The Runners", OrganizationId = 7 },
            //    new Models.Team(){ TeamId = 27, Name = "The Callers", OrganizationId = 7 },
            //    new Models.Team() { TeamId = 28, Name = "The Greeters", OrganizationId = 7 }
            //    );

            //context.Meetings.AddOrUpdate(x => x.MeetingId,
            //     new Models.Meeting() { MeetingId = 1, Name = "McDonalds", Time="2:00pm Wednesday", StreetAddress = "1711 S 9th St", City= "Milwaukee", State = "WI", TeamId = 29 },
            //     new Models.Meeting() { MeetingId = 2, Name = "St Stans", Time = "3:00pm Wednesday", StreetAddress = "3001 N Downer Ave", City = "Milwaukee", State = "WI", TeamId = 29 },
            //     new Models.Meeting() { MeetingId = 3, Name = "Pick n Save", Time = "4:00pm Wednesday", StreetAddress = "601 W Lincoln Ave", City = "Milwaukee", State = "WI", TeamId = 29 },
            //     new Models.Meeting() { MeetingId = 4, Name = "Collectivo", Time = "5:00pm Wednesday", StreetAddress = "N89 W16297 Cleveland Ave", City = "Menomonee Falls", State = "WI", TeamId = 29 },
            //     new Models.Meeting() { MeetingId = 5, Name = "Good City Brewery", Time = "6:00pm Wednesday", StreetAddress = "844 N Broadway", City = "Milwaukee", State = "WI", TeamId = 30 },
            //     new Models.Meeting() { MeetingId = 6, Name = "Walgreens", Time = "1:00pm Thursday", StreetAddress = "2490 N Cramer", City = "Milwaukee", State = "WI", TeamId = 30 },
            //     new Models.Meeting() { MeetingId = 8, Name = "Salvage Yard", Time = "2:00pm Thursday", StreetAddress = "723 W Washington Street", City = "Milwaukee", State = "WI", TeamId = 30 },
            //     new Models.Meeting() { MeetingId = 9, Name = "Collectivo", Time = "3:00pm Thursday", StreetAddress = "1720 E Norwich Ave", City = "Milwaukee", State = "WI", TeamId = 31 },
            //     new Models.Meeting() { MeetingId = 10, Name = "St.Rose Church", Time = "4:00pm Thursday", StreetAddress = "540 N 31st Street", City = "Milwaukee", State = "WI", TeamId = 31 },
            //     new Models.Meeting() { MeetingId = 11, Name = "Camp Bar", Time = "5:00pm Thursday", StreetAddress = "4500 N Oakland Ave", City = "Shorewood", State = "WI", TeamId = 31 },
            //     new Models.Meeting() { MeetingId = 12, Name = "Fiddleheads", Time = "6:00pm Thursday", StreetAddress = "2999 N Humboldt Blvd", City = "Milwaukee", State = "WI", TeamId = 31 },
            //     new Models.Meeting() { MeetingId = 13, Name = "Art Museum", Time = "11:00am Friday", StreetAddress = "700 N Art Museum Drive", City = "Milwaukee", State = "WI", TeamId = 32 },
            //     new Models.Meeting() { MeetingId = 14, Name = "Miller Park", Time = "12:00pm Friday", StreetAddress = "1 Brewers Way", City = "Milwaukee", State = "WI", TeamId = 32 },
            //     new Models.Meeting() { MeetingId = 15, Name = "Riverside", Time = "1:00pm Friday", StreetAddress = "116 W Wisconsin Ave", City = "Milwaukee", State = "WI", TeamId = 32 },
            //     new Models.Meeting() { MeetingId = 16, Name = "Marcus Hall", Time = "2:00pm Friday", StreetAddress = "3330 S 30th Street", City = "Milwaukee", State = "WI", TeamId = 39 },
            //     new Models.Meeting() { MeetingId = 17, Name = "State Fair Park", Time = "3:00pm Friday", StreetAddress = "640 S 84th Street", City = "West Allis", State = "WI", TeamId = 33 },
            //     new Models.Meeting() { MeetingId = 18, Name = "Despensa", Time = "4:00pm Friday", StreetAddress = "1615 22nd St", City = "Milwaukee", State = "WI", TeamId = 33 },
            //     new Models.Meeting() { MeetingId = 19, Name = "Lake Park", Time = "5:00pm Friday", StreetAddress = "3501 S Lake Dr", City = "St Francis", State = "WI", TeamId = 33 },
            //     new Models.Meeting() { MeetingId = 20, Name = "Pabst Theater", Time = "6:00pm Monday", StreetAddress = "144 E Wells St", City = "Milwaukee", State = "WI", TeamId = 34 },
            //     new Models.Meeting() { MeetingId = 21, Name = "Salvation Army", Time = "7:00pm Monday", StreetAddress = "1730 N 7th Street", City = "Milwaukee", State = "WI", TeamId = 34 },
            //     new Models.Meeting() { MeetingId = 22, Name = "Turner Hall", Time = "8:00pm Monday", StreetAddress = "1034 Vel R. Phillips Ave", City = "Milwaukee", State = "WI", TeamId = 34 },
            //     new Models.Meeting() { MeetingId = 23, Name = "Milwaukee Domes", Time = "9:00pm Monday", StreetAddress = "524 S Layton Blvd", City = "Milwaukee", State = "WI", TeamId = 34 },
            //     new Models.Meeting() { MeetingId = 24, Name = "Burger King", Time = "9:30pm Monday", StreetAddress = "3129 N Oakland Ave", City = "Milwaukee", State = "WI", TeamId = 35 },
            //     new Models.Meeting() { MeetingId = 25, Name = "DevCodeCamp", Time = "10:00pm Monday", StreetAddress = "313 N Plankton Ave", City = "Milwaukee", State = "WI", TeamId = 38 },
            //     new Models.Meeting() { MeetingId = 26, Name = "Mayfair Mall", Time = "3:00pm Tuesday", StreetAddress = "2500 N Mayfair Road", City = "Wauwatosa", State = "WI", TeamId = 35 },
            //     new Models.Meeting() { MeetingId = 27, Name = "Bayshore Mall", Time = "4:00pm Tuesday", StreetAddress = "5800 N Bayshore Drive", City="Glendale", State = "WI", TeamId = 40 },
            //     new Models.Meeting() { MeetingId = 28, Name = "Police Dept", Time = "5:00pm Tuesday", StreetAddress = "777 E Wisconsin Ave", City = "Milwaukee", State = "WI", TeamId = 36 },
            //     new Models.Meeting() { MeetingId = 29, Name = "Library", Time = "6:00pm Tuesday", StreetAddress = "814 W Wisconsin Ave", City = "Milwaukee", State = "WI", TeamId = 36 },
            //     new Models.Meeting() { MeetingId = 30, Name = "Marquette Campus", Time = "7:00pm Tuesday", StreetAddress = "1250 W Wisconsin Ave", City = "Milwaukee", State = "WI", TeamId = 36 },
            //     new Models.Meeting() { MeetingId = 31, Name = "Usingers Sausage", Time = "7:30pm Tuesday", StreetAddress = "1030 N Old World 3rd Street", City = "Milwaukee", State = "WI", TeamId = 37 },
            //     new Models.Meeting() { MeetingId = 32, Name = "Fiserv Forum", Time = "8:00pm Tuesday", StreetAddress = "1044 N Old World 3rd Street", City = "Milwaukee", State = "WI", TeamId = 37 },
            //     new Models.Meeting() { MeetingId = 33, Name = "Shipyard", Time = "8:30pm Tuesday", StreetAddress = "400 W Canal Street", City = "Milwaukee", State = "WI", TeamId = 37 }
 
            //     );

            //context.Teammembers.AddOrUpdate(x => x.TeammemberId,
            //new Models.TeamMember() { TeammemberId = 1, FirstName = "Erinn", LastName = "Neidinger", StreetAddress = "206 Forest View Drive", City = "Slinger", State = "WI", Email = "Erinn.Neidinger@cuw.edu" },
            //new Models.TeamMember() { TeammemberId = 2, FirstName = "Nancy", LastName = "Andrews", StreetAddress = "", City = "Milwaukee", State = "WI", Email = "Nancy.Andrews@gmail.com" },
            //new Models.TeamMember() { TeammemberId = 3, FirstName = "Zack", LastName = "Moore", StreetAddress = "", City = "West Bend", State = "WI", Email = "Zack.Moore@gmail.com" },
            //new Models.TeamMember() { TeammemberId = 4, FirstName = "Austin", LastName = "Reed", StreetAddress = "", City = "Milwaukee", State = "WI", Email = "Austin.Reed@gmail.com" },
            //new Models.TeamMember() { TeammemberId = 2, FirstName = "Cecilia", LastName = "Greene", StreetAddress = "", City = "Shorewood", State = "WI", Email = "Cecilia.Greene@gmail.com" },
            //new Models.TeamMember() { TeammemberId = 3, FirstName = "Todd", LastName = "Fin", StreetAddress = "", City = "West Allis", State = "WI", Email = "Todd.Fin@gmail.com" },
            //new Models.TeamMember() { TeammemberId = 4, FirstName = "Mary", LastName = "Taylor", StreetAddress = "", City = "Milwaukee", State = "WI", Email = "Mary.Taylor@gmail.com" });
       }
    }
}
