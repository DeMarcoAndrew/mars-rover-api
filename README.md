# Mars Rover API

 This API is designed to collect image data gathered by NASA's Curiosity Rover, Perseverance Rover, Ingenuity Helicopter, and InSight Lander on Mars and make it more easily available to other developers, educators, and citizen scientists.

# API Path Information
Each endpoint starts with: /api/{rover-name} <br>

Acceptable {rover-name}: curiosity, perseverance, insight, ingenuity 

Each endpoint will work by just using that base url above, but you can also query by sol, earth date in the form of "yyyy-MM-dd", 
and latest (only for Curiosity and Perseverance becuase those are still running as of 21 April 2026). 

# Example Paths
#### SOL: /api/curiosity/176 -> Grabs data from sol date 176 of the Curiosity rover's mission <br>
#### Earth Date: /api/perseverance/2026-04-20 -> Grabs data for Perseverance rover on Earth Date 20 April 2024 <br>
#### Latest: /api/curiosity/latest -> Grabs data from latest SOL for Curiosity rover (once again, only works for curiosity and perseverance since they aren't retired) <br>

# Grabbing Images Only
If you wish to only use the images in your project and you don't want to create models for all of the extra information that comes along with the main api path, you can add /images to the end of your path. These will come in a single string or list of strings depending on how many items you specify in the paging query.

##### Examples of this inclue: <br>
#### Base images path: /api/perseverance/images -> returns only images urls for perseverance <br>
#### Images by sol: /api/insight/402/images -> returns only images urls for insight on sol 402 of insight's mission <br>
#### Images by earth date: /api/ingenuity/2024-02-22/images -> returns only images urls for ingenuity on earth date 22 February 2024 <br>
#### Latest Images (only for curiosity and perseverance): /api/curiosity/latest -> returns latest images for curiosity rover <br>

For the image endpoints above, if you specify the per_page query to 1, it will return a single string url, otherwise it will return a list of strings []. <br>
This per_page query can be added on to any of the endpoints mentioned above. You can also specify different numbers for this query which will change the number of results that come back. <br>

*Note some endpoints may have a minmum of 10-15 results, but all endpoints will work with the value 1. To clarify this, /image?per_page=1 will work for all, but /image?per_page=5 might not work for all endpoints. <br>

Example for a singe string return type: /api/perseverance/182/images?per_page=1 -> returns a string url for an image taken by perseverance rover on sol 182.

In addition, the Perseverance and Ingenuity endpoints can have a size query of small, medium, or large. The default if no size is specified will be NASA's Full Resolution photo url. <br>
Example of size query: /api/perseverance/images?per_page=1&size=large -> returns a single string url link for a large image taken by perseverance rover. <br>

# API Query Params
Possible Queries for every rover endpoint ( first one will be ?{query-here}={value-here} and
any following ones will be &{next-query-here}={value-here} ) <br>

| Page                             | Per Page                     | Camera                                                                                               |
| -------------------------------- | ---------------------------- | ---------------------------------------------------------------------------------------------------- |
| integer                          | integer                      | string                                                                                               |
| example: ?page=2                 | example: <br> ?per_page=25   | ex: ?camera=FHAZ_RIGHT_A                                                                             |
| *Note must be used with per_page |                              | querying multiple cameras can be done by separating <br> each camera with the pipe character: &#124; |

### Cameras <br>
Each Rover has a set of cameras you can use to filter your search. Below is a table with the Camera and the abbreviation you will use for the API: <br>

#### Curiosity Rover: <br>
| Camera                           | API Abbreviations                 |
| -------------------------------- | --------------------------------- |
| Front Hazcam - Left              | FHAZ_LEFT_A <br> FHAZ_LEFT_B      |
| Front Hazcam - Right             | FHAZ_RIGHT_A <br> FHAZ_RIGHT_B    |
| Rear Hazcam - Left               | RHAZ_LEFT_A <br> RHAZ_LEFT_B      |
| Rear Hazcam - Right              | RHAZ_RIGHT_A <br> RHAZ_RIGHT_B    |
| Left Navigation Camera           | NAV_LEFT_A <br> NAV_LEFT_B        |
| Right Navigation Camera          | NAV_Right_A <br> NAV_Right_B      |
| Chemistry & Camera (ChemCam)     | CHEMCAM_RMI                       |
| Mars Descent Imager (MARDI)      | MARDI                             |
| Mars Hand Lens Imager (MAHLI)    | MAHLI                             |
| Mast Camera (Mastcam)            | MAST_LEFT <br> MAST_RIGHT         |

#### Perseverance Rover: <br>
| Camera                           | API Abbreviations                              |
| -------------------------------- | ---------------------------------------------- |
| Front Hazcam - Left              | FRONT_HAZCAM_LEFT_A <br> FRONT_HAZCAM_LEFT_B   |
| Front Hazcam - Right             | FRONT_HAZCAM_RIGHT_A <br> FRONT_HAZCAM_RIGHT_B |
| Rear Hazcam - Left               | REAR_HAZCAM_LEFT                               |
| Rear Hazcam - Right              | REAR_HAZCAM_RIGHT                              |
| Left Navigation Camera           | NAVCAM_LEFT                                    |
| Right Navigation Camera          | NAVCAM_Right                                   |
| Sample Caching System (CacheCam) | CACHECAM                                       |
| Mastcam-Z - Lef                  | MCZ_LEFT                                       |
| Mastcam-Z - Right                | MCZ_RIGHT                                      |
| MEDA SkyCam                      | SKYCAM                                         |
| PIXL Micro Context Camera        | PIXL_MCC                                       |
| SHERLOC - WATSON                 | SHERLOC_WATSON                                 |
| SHERLOC Context Imager           | SHERLOC_ACI                                    |
| SuperCam Remote Micro Imager     | SUPERCAM_RMI                                   |
| Parachute Up-Look Camera         | EDL_PUCAM1 <br> EDL_PUCAM2                     |
| Descent Stage Down-Look Camera   | EDL_DDCAM                                      |
| Rover Up-Look Camera             | EDL_RUCAM                                      |
| Rover Down-Look Camera           | EDL_RDCAM                                      |
| Lander Vision System Camera      | LCAM                                           |

#### InSight Lander <br>
| Camera                                   | API Abbreviations |
| -----------------------------------------| ----------------- |
| Instrument Deployment Camera (IDC)       | idc               |
| Instrument Context Camera (ICC)          | icc               |

#### Ingenuity Helicopter <br>
| Camera               | API Abbreviations |
| -------------------- | ----------------- |
| Navigation Camera    | HELI_NAV          |
| Color Camera         | HELI_RTE          |

# Contributing
If you would like to contribute to this Mars Rover API, feel free to create a pull request.

Fork this repository,
Create your feature branch,
Commit your changes,
Push to the branch,
Create a new Pull Request
