using System.Collections.Generic;
using Newtonsoft.Json;

namespace NEOApp.Models
{
  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
  public class Links
  {
    public string Next { get; set; }
    public string Prev { get; set; }
    public string Self { get; set; }
  }

  public class Kilometers
  {
    [JsonProperty("estimated_diameter_min")]
    public double EstimatedDiameterMin { get; set; }

    [JsonProperty("estimated_diameter_max")]
    public double EstimatedDiameterMax { get; set; }
  }

  public class Meters
  {
    [JsonProperty("estimated_diameter_min")]
    public double EstimatedDiameterMin { get; set; }

    [JsonProperty("estimated_diameter_max")]
    public double EstimatedDiameterMax { get; set; }
  }

  public class Miles
  {
    [JsonProperty("estimated_diameter_min")]
    public double EstimatedDiameterMin { get; set; }

    [JsonProperty("estimated_diameter_max")]
    public double EstimatedDiameterMax { get; set; }
  }

  public class EstimatedDiameter
  {
    public Kilometers Kilometers { get; set; }
    public Meters Meters { get; set; }
    public Miles Miles { get; set; }
  }

  public class RelativeVelocity
  {
    [JsonProperty("kilometers_per_second")]
    public string KilometersPerSecond { get; set; }

    [JsonProperty("kilometers_per_hour")]
    public string KilometersPerHour { get; set; }

    [JsonProperty("miles_per_hour")]
    public string MilesPerHour { get; set; }
  }

  public class MissDistance
  {
    public string Astronomical { get; set; }
    public string Lunar { get; set; }
    public string Kilometers { get; set; }
    public string Miles { get; set; }
  }

  public class CloseApproachData
  {
    [JsonProperty("close_approach_date_full")]
    public string CloseApproachDateFull { get; set; }

    [JsonProperty("relative_velocity")]
    public RelativeVelocity RelativeVelocity { get; set; }

    [JsonProperty("miss_distance")]
    public MissDistance MissDistance { get; set; }

    [JsonProperty("orbiting_body")]
    public string OrbitingBody { get; set; }
  }

  public class OrbitalData
  {
    [JsonProperty("first_observation_date")]
    public string FirstObservationDate { get; set; }

    [JsonProperty("last_observation_date")]
    public string LastObservationDate { get; set; }

    [JsonProperty("observations_used")]
    public int ObservationsUsed { get; set; }
  }

  public class NEO
  {
    public Links Links { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }

    [JsonProperty("nasa_jpl_url")]
    public string NasaJplUrl { get; set; }

    [JsonProperty("absolute_magnitude_h")]
    public double AbsoluteMagnitudeH { get; set; }

    [JsonProperty("estimated_diameter")]
    public EstimatedDiameter EstimatedDiameter { get; set; }

    [JsonProperty("is_potentially_hazardous_asteroid")]
    public bool IsPotentiallyHazardousAsteroid { get; set; }

    [JsonProperty("close_approach_data")]
    public List<CloseApproachData> CloseApproachData { get; set; }

    [JsonProperty("orbital_data")]
    public OrbitalData OrbitalData { get; set; }
  }

  public class NearEarthObjects
  {
    public List<NEO> Neos { get; set; }
  }
  public class NEOFeed
  {
    public Links Links { get; set; }

    [JsonProperty("element_count")]
    public int ElementCount { get; set; }

    [JsonProperty("near_earth_objects")]
    public NearEarthObjects NearEarthObjects { get; set; }

  }


}