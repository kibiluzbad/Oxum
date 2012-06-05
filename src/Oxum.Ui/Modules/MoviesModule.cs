using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Json;
using Oxum.Ui.Domain;
using Raven.Client;

namespace Oxum.Ui.Modules
{
    public class MoviesModule : NancyModule
    {
        public MoviesModule(IDocumentSession session)
        {
            Get["/"] = parameters =>
                           {
                               var movies = session.Query<Movie>().ToList();
                               return Response.AsJson(movies);
                           };
        }
    }
}