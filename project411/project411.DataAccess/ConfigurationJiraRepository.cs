URL, repository_name = @repositoryName, title = @title, username = @username, action = @action, no_of_entries = @noOfEntries,
                            pagination = @pagination, page_numbers = @pageNumbers, add_more = @addMore, pop_up_form = @popUpForm
                            WHERE id = @id;";

            var param = new
            {
                model.Id,
                model.SacralAiWebsite,
                model.ExpertServicesPage,
                model.Configure,
                model.JiraSoftware,
                model.JiraUsername,
                model.JiraPassword,
                model.JiraURL,
                model.RepositoryName,
                model.Title,
                model.UserName,
                model.Action,
                model.NoOfEntries,
                model.Pagination,
                model.PageNumbers,
                model.AddMore,
                model.PopUpForm
            };

            return await _conn.ExecuteAsync(query, param);
        }
    }

    public interface IConfigurationJiraRepository
    {
        Task<ConfigurationJiraModel> GetConfigurationJiraModelByIdAsync(int id);
        Task<int> CreateConfigurationJiraModelAsync(ConfigurationJiraModel model);
        Task<int> UpdateConfigurationJiraModelAsync(ConfigurationJiraModel model);
    }
}