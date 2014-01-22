﻿using System;
using System.Linq;
using Movies.Mappings;
using System.Collections.Generic;

namespace Movies.Repositories
{
    public class MovieRepository
    {
        MoviesEntities db;

        public MovieRepository()
        {
            db = new MoviesEntities();
        }

        public bool addMovie(movie temp)
        {
            try
            {
                db.movies.Add(temp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                db.movies.Remove(temp);
                return false;
            }
        }

        public movie getMovieById(int id)
        {
            return db.movies.Where(a => a.id.Equals(id)).FirstOrDefault();
        }

        public movie getMovieByTitle(string title)
        {
            return db.movies.Where(a => a.title.Equals(title)).FirstOrDefault();
        }

        /// <summary>
        /// Wyszukuje filmy zawierające argument w tytule
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IQueryable<movie> getMovieByTitleSubstring(string substring)
        {
            return db.movies.Take(10) 
                           .Where(a => a.title.Contains(substring));
        }

        public IQueryable<cast> getCastByMovieId(int id)
        {
           return db.casts.Where(a => a.id.Equals(id));
            
        }

        public bool deleteMovieById(int id)
        {
            try
            {
                foreach(cast c in getCastByMovieId(id))
                {
                    db.casts.Remove(c);
                }

                db.movies.Remove(getMovieById(id));

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<movie> getSimilarMoviesByMovieId(int id)
        {
            IQueryable<movie_relation> temp = from a in db.movie_relation
                                              where
                                                  a.movie_1_id == id || a.movie_2_id == id
                                              select a;

            List<movie> movieList = new List<movie>();

            foreach (movie_relation tempRel in temp)
            {
                if (tempRel.movie_1_id.Equals(id))
                    movieList.Add(getMovieById(tempRel.movie_2_id));
                else
                    movieList.Add(getMovieById(tempRel.movie_1_id));
            }

            return movieList;       
        }
    }
}