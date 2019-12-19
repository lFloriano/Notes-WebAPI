using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Notes_API.Models
{
    public class NoteRepository : INoteRepository
    {
        static string connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connString);

        public List<Note> GetAll()
        {
            string query = @"SELECT * FROM  tbl_notes ORDER BY Creation DESC";
            
            SqlCommand command = new SqlCommand() { Connection = connection, CommandText = query };
            SqlDataReader reader;
            List<Note> notesList = new List<Note>();
            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    notesList.Add(
                        new Note()
                        {
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            Creation = Convert.ToDateTime(reader["Creation"].ToString())
                        }
                    );
                }
                
            }
            catch(Exception ex)
            {
                //TODO: do something about errors
            }
            finally
            {
                connection.Close();
            }

            return notesList;
        }

        public Note Get(int id)
        {
            string query = @"SELECT * FROM tbl_notes WHERE Id = @NoteId";
            SqlCommand command = new SqlCommand() { Connection = connection, CommandText = query };
            SqlDataReader reader;
            Note note = null;

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("NoteId", id);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    note = new Note()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Title = reader["Title"].ToString(),
                        Content = reader["Content"].ToString(),
                        Creation = Convert.ToDateTime(reader["Creation"].ToString())
                    };
                }
            }
            catch(Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return note;
        }

        public int Add(Note note)
        {
            string query = @"";
            SqlCommand command = new SqlCommand() { Connection = connection, CommandText = query };
            int returnValue = -1;

            try
            {
                connection.Open();

                command.Parameters.AddWithValue("Title", note.Title);
                command.Parameters.AddWithValue("Content", note.Content);
                command.Parameters.AddWithValue("Creation", DateTime.Now);

                returnValue = (int)command.ExecuteScalar();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return returnValue;
        }

        public bool Update(Note note)
        {
            bool returnValue = false;
            string query = @"";
            SqlCommand command = new SqlCommand() { Connection = connection, CommandText = query };

            try
            {
                connection.Open();
                command.Parameters.AddWithValue("Title", note.Title);
                command.Parameters.AddWithValue("Content", note.Content);
                command.Parameters.AddWithValue("Updated", DateTime.Now);

                //TODO: avaliar se esse cast realmente retorna false p/ 0 e valores negativos
                returnValue = Convert.ToBoolean(command.ExecuteNonQuery());

            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return returnValue;
        }

        public bool Delete(int id)
        {
            string query = @"";
            SqlCommand command = new SqlCommand() { Connection = connection, CommandText = query };
            bool returnValue = false;

            try
            {
                connection.Open();
                returnValue = Convert.ToBoolean(command.ExecuteNonQuery());
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return returnValue;
        }

    }
}