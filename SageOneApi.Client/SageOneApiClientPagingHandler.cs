using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal class SageOneApiClientPagingHandler : SageOneApiClientBaseHandler
    {
        public SageOneApiClientPagingHandler(ISageOneApiClient apiClient) : base(apiClient) { }

        public override IEnumerable<T> GetAll<T>() 
        {
            return getPagedEntities<T>();
        }

        private IEnumerable<T> getPagedEntities<T>(List<T> entities = null, int pageNumber = 1) where T : class
        {
            entities = entities ?? new List<T>();

            var summaryResponse = GetAllSummary<T>();

            foreach (var item in summaryResponse.items)
            {
                var entity = Get<T>(item.id);

                entities.Add(entity);
            }

            if (summaryResponse.next != null)
            {
                pageNumber += 1;

                getPagedEntities(entities, pageNumber);
            }

            return entities;
        }
    }
}
