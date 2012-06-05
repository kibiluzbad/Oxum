﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;

namespace Oxum.Ui.Tests
{
    [TestFixture]
    public class MoviesModuleTests
    {
        private const string _movieJson = "{\"recomendations\":[],\"rating\":7.2,\"votes\":139264.0,\"title\":\"There's Something About Mary\",\"writers\":[{\"name\":\"Ed Decter\",\"url\":\"http://www.imdb.com/name/nm0214036/\",\"imdbid\":\"nm0214036\"},{\"name\":\"John J. Strauss\",\"url\":\"http://www.imdb.com/name/nm0833828/\",\"imdbid\":\"nm0833828\"}],\"plot\":\"A man gets a chance to meet up with his dream girl from highschool, even though his date with her back then was a complete disaster.\",\"tagline\":\"There's Just Something About Her...\",\"alternative_titles\":[{\"title\":\"Ah Mary vah Mary\",\"country\":\"Turkey (Turkish title)\"},{\"title\":\"Algo m\u00e1s pasa con Mary\",\"country\":\"Spain (video title)\"},{\"title\":\"Algo pasa con Mary\",\"country\":\"Spain\"},{\"title\":\"Alle elsker Mary\",\"country\":\"Norway (imdb display title)\"},{\"title\":\"Den d\u00e4r Mary\",\"country\":\"Sweden\"},{\"title\":\"Doidos por Mary\",\"country\":\"Portugal\"},{\"title\":\"Ima nesto u vezi Meri\",\"country\":\"Serbia (imdb display title)\"},{\"title\":\"Kati trehei me ti Mary\",\"country\":\"Greece (transliterated ISO-LATIN-1 title)\"},{\"title\":\"Keresd a n\u0151t!\",\"country\":\"Hungary\"},{\"title\":\"Loco por Mary\",\"country\":\"Argentina\"},{\"title\":\"Marie a un je-ne-sais-quoi\",\"country\":\"Canada (French title)\"},{\"title\":\"Mary \u00e0 tout prix\",\"country\":\"France\"},{\"title\":\"Mary ni kubitakke\",\"country\":\"Japan\"},{\"title\":\"Neco na t\u00e9 Mary je\",\"country\":\"Czech Republic\"},{\"title\":\"Nieco na tej Mary je\",\"country\":\"Slovakia\"},{\"title\":\"Nori na Mary\",\"country\":\"Slovenia\"},{\"title\":\"Quem Vai Ficar Com Mary?\",\"country\":\"Brazil\"},{\"title\":\"Sekaisin Marista\",\"country\":\"Finland\"},{\"title\":\"Spos\u00f3b na blondynke\",\"country\":\"Poland (imdb display title)\"},{\"title\":\"There's Something More About Mary\",\"country\":\"USA (DVD title)\"},{\"title\":\"Tutti pazzi per Mary\",\"country\":\"Italy\"},{\"title\":\"Verr\u00fcckt nach Mary\",\"country\":\"Germany\"},{\"title\":\"Vild med Mary\",\"country\":\"Denmark\"}],\"top250\":null,\"runtime\":\"\",\"year\":\"1998\",\"directors\":[{\"name\":\"Bobby Farrelly\",\"url\":\"http://www.imdb.com/name/nm0268370/\",\"imdbid\":\"nm0268370\"},{\"name\":\"Peter Farrelly\",\"url\":\"http://www.imdb.com/name/nm0268380/\",\"imdbid\":\"nm0268380\"}],\"picture_path\":\"http://ia.media-imdb.com/images/M/MV5BMjA0OTU2MzYwOV5BMl5BanBnXkFtZTYwNTA3OTk5._V1._SY317_CR5,0,214,317_.jpg\",\"cast\":[{\"name\":\"Mary\",\"actor\":\"Cameron Diaz\",\"url\":\"http://www.imdb.com/name/nm0000139/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0136448\"},{\"name\":\"Healy\",\"actor\":\"Matt Dillon\",\"url\":\"http://www.imdb.com/name/nm0000369/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0141902\"},{\"name\":\"Ted\",\"actor\":\"Ben Stiller\",\"url\":\"http://www.imdb.com/name/nm0001774/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0141903\"},{\"name\":\"Tucker\",\"actor\":\"Lee Evans\",\"url\":\"http://www.imdb.com/name/nm0262968/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003163\"},{\"name\":\"Dom\",\"actor\":\"Chris Elliott\",\"url\":\"http://www.imdb.com/name/nm0254402/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0143355\"},{\"name\":\"Magda\",\"actor\":\"Lin Shaye\",\"url\":\"http://www.imdb.com/name/nm0005417/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003161\"},{\"name\":\"Sully\",\"actor\":\"Jeffrey Tambor\",\"url\":\"http://www.imdb.com/name/nm0001787/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003158\"},{\"name\":\"Mary's Mom\",\"actor\":\"Markie Post\",\"url\":\"http://www.imdb.com/name/nm0692850/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003164\"},{\"name\":\"Brenda\",\"actor\":\"Sarah Silverman\",\"url\":\"http://www.imdb.com/name/nm0798971/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003152\"},{\"name\":\"Detective Krevoy\",\"actor\":\"Richard Tyson\",\"url\":\"http://www.imdb.com/name/nm0879186/\",\"picture_path\":\"http://i.media-imdb.com/images/SF984f0c61cc142e750d1af8e5fb4fc0c7/nopicture/small/name.png\",\"imdbid\":\"ch0003162\"}],\"genres\":[\"Comedy\",\"Romance\"],\"imdbid\":\"tt0129387\",\"akas\":[\"There's Something More About Mary\"]}";

        [Test]
        public void Should_return_all_movies_for_root()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            var result = browser.Get("/", with =>
                                              {
                                                  with.HttpRequest();
                                                  with.Header("content-type", "application/json");
                                              });

            Assert.That(result.Body, Is.EqualTo(_movieJson));
        }
    }
}
