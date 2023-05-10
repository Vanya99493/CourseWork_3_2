using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DictionaryTranslator.Scripts.Data
{
    public class DataController
    {
        private const string CONNECTION_STRING = "Data Source=dictionary_translator.db;";

        private static DataController _instance;
        private SQLiteConnection _sqlConnection;

        public static DataController Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DataController();
                }
                return _instance;
            }
        }

        public DataController()
        {
            _sqlConnection = new SQLiteConnection(CONNECTION_STRING);
            _sqlConnection.Open();
        }

        public bool EnterInProgram(string login, string password)
        {
            string query = "SELECT * from user;";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["login"].ToString() == login && sqlDataReader["password"].ToString() == password)
                {
                    sqlDataReader.Close();
                    return true;
                }
            }
            sqlDataReader.Close();
            return false;
        }

        public bool RegistrationInProgram(string login, string password)
        {
            string query = "SELECT * from user;";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["login"].ToString() == login)
                {
                    sqlDataReader.Close();
                    return false;
                }
            }

            if (password.Length < 8)
            {
                return false;
            }

            string insertQery = "INSERT INTO user (login, password) VALUES (@login, @password)";
            using (SQLiteCommand command = new SQLiteCommand(insertQery, _sqlConnection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
            }

            sqlDataReader.Close();

            return true;
        }

        public List<string> GetAllLibraries(string userName)
        {
            List<string> libraries = new List<string>();
            string query = $"SELECT name from favorites, user where user.user_id = favorites.user_id and user.login = '{userName}';";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                libraries.Add(sqlDataReader.GetString(0));
            }
            sqlDataReader.Close();
            return libraries;
        }

        public bool GetTranslation(out string targetWord, string sourceWord, string sourceWordLanguage, string targetWordLanguage)
        {
            string query = "SELECT w.word AS source_word, t.word AS target_word, sl.language AS source_word_language, tl.language AS target_word_language FROM translations tr INNER JOIN words w ON tr.source_word_id = w.word_id INNER JOIN words t ON tr.target_word_id = t.word_id INNER JOIN languages sl ON w.language_id = sl.language_id INNER JOIN languages tl ON t.language_id = tl.language_id;";
            StringBuilder translation = new StringBuilder();
            bool isTranslate = false;

            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["source_word"].ToString().ToLower() == sourceWord.ToLower() && 
                    sqlDataReader["source_word_language"].ToString().ToLower() == sourceWordLanguage.ToLower() && 
                    sqlDataReader["target_word_language"].ToString().ToLower() == targetWordLanguage.ToLower())
                {
                    if (!isTranslate)
                    {
                        translation.Append(sqlDataReader["target_word"].ToString().ToLower());
                        isTranslate = true;
                    }
                    else
                    {
                        translation.Append(",\n" + sqlDataReader["target_word"].ToString().ToLower());
                    }
                } else if (sqlDataReader["target_word"].ToString().ToLower() == sourceWord.ToLower() &&
                    sqlDataReader["target_word_language"].ToString().ToLower() == sourceWordLanguage.ToLower() &&
                    sqlDataReader["source_word_language"].ToString().ToLower() == targetWordLanguage.ToLower())
                {
                    if (!isTranslate)
                    {
                        translation.Append(sqlDataReader["source_word"].ToString().ToLower());
                        isTranslate = true;
                    }
                    else
                    {
                        translation.Append(",\n" + sqlDataReader["source_word"].ToString().ToLower());
                    }
                }
            }
            sqlDataReader.Close();
            targetWord = translation.ToString();
            return isTranslate;
        }

        public void AddTranslation(string sourceWord, string targetWord, string sourceWordLanguage, string targetWordLanguage)
        {
            int sourceWordId, targetWordId;

            GetWordId(out sourceWordId, sourceWord, sourceWordLanguage);
            GetWordId(out targetWordId, targetWord, targetWordLanguage);

            if(sourceWordId != -1 && targetWordId != -1) {}
            else
            {
                if (sourceWordId == -1)
                {
                    sourceWordId = AddWord(sourceWord, sourceWordLanguage);
                }
                if (targetWordId == -1)
                {
                    targetWordId = AddWord(targetWord, targetWordLanguage);
                }
            }
            if(sourceWordId == -1 || targetWordId == -1)
            {
                MessageBox.Show($"Error. SWId = {sourceWordId}; TWId = {targetWordId}");
            }

            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT * from translations where translations.source_word_id = {sourceWordId} and translations.target_word_id = {targetWordId};", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                sqlDataReader.Close();
                MessageBox.Show("Translation has already been created");
                return;
            }
            sqlDataReader.Close();

            string insertQery = "INSERT INTO translations (source_word_id, target_word_id) VALUES (@source_word_id, @target_word_id)";
            using (SQLiteCommand command = new SQLiteCommand(insertQery, _sqlConnection))
            {
                command.Parameters.AddWithValue("@source_word_id", sourceWordId);
                command.Parameters.AddWithValue("@target_word_id", targetWordId);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Successfully");

            sqlDataReader.Close();
        }

        public int AddWord(string word, string language)
        {
            int languageId = -1,
                wordId = -1;

            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT * from languages where languages.language = '{language}'", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                languageId = Convert.ToInt32(sqlDataReader["language_id"].ToString());
            }
            sqlDataReader.Close();

            sqlCommand = new SQLiteCommand($"INSERT INTO words (word, language_id) VALUES ('{word}', '{languageId}')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlCommand = new SQLiteCommand($"SELECT word_id from words where word = '{word}' and language_id = '{languageId}';", _sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                wordId = Convert.ToInt32(sqlDataReader["word_id"].ToString());
            }
            sqlDataReader.Close();

            return wordId;
        }

        public void AddCategoryToWord(string word, string category)
        {
            int categoryId = -1;
            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT * from categories where category_name = '{category}'", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                categoryId = Convert.ToInt32(sqlDataReader["category_id"].ToString());
            }
            sqlDataReader.Close();

            sqlCommand = new SQLiteCommand($"UPDATE words SET category_id = {categoryId} where word = '{word}';", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public bool AddLanguage(string language)
        {
            string query = "SELECT * from languages;";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);

            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["language"].ToString().ToLower() == language.ToLower())
                {
                    sqlDataReader.Close();
                    return false;
                }
            }

            string insertQery = "INSERT INTO languages (language) VALUES (@language)";
            using (SQLiteCommand command = new SQLiteCommand(insertQery, _sqlConnection))
            {
                command.Parameters.AddWithValue("@language", language);
                command.ExecuteNonQuery();
            }
            sqlDataReader.Close();
            return true;
        }

        public DataView GetFavoriteList(string favoriteListName)
        {
            int favoriteListIndex = -1;

            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT * from favorites where name in ('{favoriteListName}');", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["name"].ToString().ToLower() == favoriteListName.ToLower())
                {
                    favoriteListIndex = Convert.ToInt32(sqlDataReader["favorite_id"].ToString().ToLower());
                }
            }

            string query = $"SELECT w.word AS source_word, t.word AS target_word, sl.language AS source_word_language, tl.language AS target_word_language FROM translations tr JOIN words w ON w.word_id = tr.source_word_id JOIN words t ON t.word_id = tr.target_word_id JOIN languages sl ON sl.language_id = w.language_id JOIN languages tl ON tl.language_id = t.language_id JOIN translation_favorite tf ON tf.translation_id = tr.translation_id JOIN favorites f ON f.favorite_id = tf.favorite_id WHERE f.favorite_id = {favoriteListIndex};";
            return GetDataView(query);
        }

        public DataView GetDataView(string query)
        {   
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("DataTable");
            try
            {
                sqlDataAdapter.Fill(dataTable);
            }
            catch (SQLiteException)
            {
                MessageBox.Show("SQLite error");
            }
            return dataTable.DefaultView;
        }

        public void SaveToLibrary(string libraryName, string sourceWord, string targetWord, string sourceWordLanguage, string targetWordLanguage)
        {
            int sourceWordId, targetWordId;
            if(!GetWordId(out sourceWordId, sourceWord, sourceWordLanguage))
            {
                MessageBox.Show("Save word to library error");
                return;
            }
            if(!GetWordId(out targetWordId, targetWord, targetWordLanguage))
            {
                MessageBox.Show("Save word to library error");
                return;
            }

            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT T.translation_id, T.source_word_id, W1.word as source_word, T.target_word_id, W2.word as target_word from translations T left join words W1 on W1.word_id = T.source_word_id left join words W2 on W2.word_id = T.target_word_id where (T.source_word_id = {sourceWordId} and T.target_word_id = {targetWordId}) or (T.source_word_id = {targetWordId} and T.target_word_id = {sourceWordId});", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int translationId = -1;
            while (sqlDataReader.Read())
            {
                translationId = Convert.ToInt32(sqlDataReader["translation_id"].ToString());
            }
            sqlDataReader.Close();

            sqlCommand = new SQLiteCommand($"SELECT * from favorites where name = '{libraryName}';", _sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            int favoriteId = -1;
            while (sqlDataReader.Read())
            {
                favoriteId = Convert.ToInt32(sqlDataReader["favorite_id"].ToString());
            }
            sqlDataReader.Close();

            if(translationId == -1 || favoriteId == -1)
            {
                MessageBox.Show("Save word to library error");
            }

            sqlCommand = new SQLiteCommand($"INSERT INTO translation_favorite (translation_id, favorite_id) VALUES ('{translationId}', '{favoriteId}')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public void AddNewLibrary(string login, string newLibraryName)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT user_id from user where login like '{login}';", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int userId = -1;
            while (sqlDataReader.Read())
            {
                userId = Convert.ToInt32(sqlDataReader["user_id"].ToString());
            }
            sqlDataReader.Close();

            sqlCommand = new SQLiteCommand($"INSERT INTO favorites (user_id, name) VALUES ({userId}, '{newLibraryName}')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public bool AddNewCategory(string newCategory)
        {
            string query = "SELECT category_name from categories;";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);

            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["category_name"].ToString().ToLower() == newCategory.ToLower())
                {
                    sqlDataReader.Close();
                    return false;
                }
            }
            sqlDataReader.Close();

            sqlCommand = new SQLiteCommand($"INSERT INTO categories (category_name) VALUES ('{newCategory}')", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
            return true;
        }

        public List<string> GetWords()
        {
            return GetDataList("words", "word");
        }

        public List<string> GetCategories()
        {
            return GetDataList("categories", "category_name");
        }

        public List<string> GetFavorites()
        {
            return GetDataList("favorites", "name");
        }

        public List<string> GetLanguages()
        {
            return GetDataList("languages", "language");
        }

        public void DeleteWord(string word)
        {
            DeleteField("words", $"word = '{word}'");
        }

        public void DeleteCategory(string categoryName)
        {
            DeleteField("categories", $"category_name = '{categoryName}'");
        }

        public void DeleteFavoriteList(string listName)
        {
            DeleteField("favorites", $"name = '{listName}'");
        }

        public void DeleteLanguage(string language)
        {
            DeleteField("languages", $"language = '{language}'");
        }

        private List<string> GetDataList(string tableName, string fieldName)
        {
            List<string> list = new List<string>();
            string query = $"SELECT {fieldName} from {tableName};";
            SQLiteCommand sqlCommand = new SQLiteCommand(query, _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader[fieldName].ToString());
            }
            sqlDataReader.Close();
            return list;
        }

        private void DeleteField(string tableName, string condition)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand($"DELETE FROM {tableName} where {condition};", _sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        private bool GetWordId(out int wordId, string word, string wordLanguage)
        {
            wordId = -1;
            SQLiteCommand sqlCommand = new SQLiteCommand($"SELECT W.word, W.word_id, L.language from words W, languages L where W.language_id = L.language_id and L.language = '{wordLanguage}';", _sqlConnection);
            SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader["word"].ToString().ToLower() == word.ToLower())
                {
                    wordId = Convert.ToInt32(sqlDataReader["word_id"].ToString());
                    return true;
                }
            }
            sqlDataReader.Close();
            return false;
        }
    }
}