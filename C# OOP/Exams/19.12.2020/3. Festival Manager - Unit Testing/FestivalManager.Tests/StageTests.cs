// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

        [SetUp]
        public void Setup()
        {
            this.stage = new Stage();
        }

        [Test]
		public void Constructor_Should_Initialize_Correctly()
        {
			Assert.IsNotNull(this.stage.Performers);
			Assert.AreEqual(0, this.stage.Performers.Count);
        }

		[Test]
		public void AddPerformer_Should_Add_Correctly()
        {
			var performer = new Performer("Petar", "Petrov", 22);

			this.stage.AddPerformer(performer);

			Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
			Assert.IsTrue(this.stage.Performers.Any(p => p.FullName == "Petar Petrov"));
        }

		[Test]
		public void AddPerformer_Should_Throw_An_Error_If_The_Performer_Is_Under_18()
        {
			var performer = new Performer("Petar", "Petrov", 15);

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddPerformer(performer);
			});
		}

		[Test]
		public void AddPerformer_Should_Throw_An_Error_If_The_Performer_Is_NULL()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddPerformer(null);
			});
		}

		[Test]
		public void AddSong_Should_Throw_An_Error_If_The_Duration_Is_Under_1_Minute()
		{
			var song = new Song("ZZZ", new TimeSpan(0, 0, 15));

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSong(song);
			});
		}

		[Test]
		public void AddSong_Should_Throw_An_Error_If_The_Song_Is_NULL()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddSong(null);
			});
		}

		[Test]
		public void AddSongToPerformer_Should_Throw_An_Error_If_The_Song_Name_Is_NULL()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddSongToPerformer(null, "ZZZ");
			});
		}

		[Test]
		public void AddSongToPerformer_Should_Throw_An_Error_If_The_Performer_Name_Is_NULL()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				this.stage.AddSongToPerformer("ZZZ", null);
			});
		}

		[Test]
		public void AddSongToPerformer_Should_Throw_An_Error_If_The_Performer_Is_Not_Existing()
		{
			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSongToPerformer("ZZZ", "Pesho");
			});
		}

		[Test]
		public void AddSongToPerformer_Should_Throw_An_Error_If_The_Song_Is_Not_Existing()
		{
			this.stage.AddPerformer(new Performer("Pesho", "Peshiv", 20));

			Assert.Throws<ArgumentException>(() =>
			{
				this.stage.AddSongToPerformer("YYY", "Pesho Peshev");
			});
		}

		[Test]
		public void AddSongToPerformer_Should_Be_Add_Successfully()
		{
			var song = new Song("Gradil Iliya Kiliya", new TimeSpan(0, 3, 31));
			var performer = new Performer("Ivan", "Dyakov", 43);

			this.stage.AddSong(song);
			this.stage.AddPerformer(performer);

			this.stage.AddSongToPerformer(song.Name, performer.FullName);
		}

		[Test]
		public void Play_Should_Return_Correct_Result()
		{
			var song = new Song("Gradil Iliya Kiliya", new TimeSpan(0, 3, 31));
			var performer = new Performer("Ivan", "Dyakov", 43);

			this.stage.AddSong(song);
			this.stage.AddPerformer(performer);

			this.stage.AddSongToPerformer(song.Name, performer.FullName);

			var result = this.stage.Play();

			Assert.That(result, Is.EqualTo($"1 performers played 1 songs"));
		}
	}
}