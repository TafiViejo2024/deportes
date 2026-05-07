namespace Futbol5.Api.Services
{
    public class FixtureService
    {
        public List<(int, int)> GenerarRoundRobin(List<int> equipos)
        {
            var partidos = new List<(int, int)>();

            for (int i = 0; i < equipos.Count; i++)
            {
                for (int j = i + 1; j < equipos.Count; j++)
                {
                    partidos.Add((equipos[i], equipos[j]));
                }
            }

            return partidos;
        }
    }
}
