Mars Rover Photo API

This API is designed to collect image data gathered by NASA's Curiosity Rover, Perseverance Rover, Ingenuity Helicopter, and InSight Lander on Mars and make it more easily available to other developers, educators, and citizen scientists.

Each endpoint starts with: /api/{rover-name}

Acceptable {rover-name}: curiosity, perseverance, insight, ingenuity 

Each endpoint will work by just using that base url above, but you can also query by sol, earth date in the form of "yyyy-MM-dd", 
and latest (only for Curiosity and Perseverance becuase those are still running as of 21 April 2026). 

Below are example paths for each endpoint:
SOL: /api/curiosity/176 -> Grabs data from sol date 176 of the Curiosity rover's mission
Earth Date: /api/perseverance/2026-04-20 -> Grabs data for Perseverance rover on Earth Date 20 April 2024
Latest: /api/curiosity/latest -> Grabs data from latest SOL for Curiosity rover (once again, only works for curiosity and perseverance since they aren't retired)

Grabbing Images Only: If you wish to only use the images in your project and you don't want to create models for all of the extra information that comes along with the main api path, you can add /images to the end of your path. These will come in a single string or list of strings depending on how many items you specify in the paging query.

Examples of this inclue:
Base images path: /api/perseverance/images -> returns only images urls for perseverance
Images by sol: /api/insight/402/images -> returns only images urls for insight on sol 402 of insight's mission
Images by earth date: /api/ingenuity/2024-02-22/images -> returns only images urls for ingenuity on earth date 22 February 2024
Latest Images (only for curiosity and perseverance): /api/curiosity/latest -> returns latest images for curiosity rover

For the image endpoints above, if you specify the per_page query to 1, it will return a single string url, otherwise it will return a list of strings []. 
This per_page query can be added on to any of the endpoints mentioned above. You can also specify different numbers for this query which will change the number of results that come back. '
*Note some endpoints may have a minmum of 10-15 results, but all endpoints will work with the value 1. To clarify this, /image?per_page=1 will work for all, but /image?per_page=5 might not work for all endpoints.

Example for a singe string return type: /api/perseverance/182/images?per_page=1 -> returns a string url for an image taken by perseverance rover on sol 182. 

In addition, the Perseverance and Ingenuity endpoints can have a size query of small, medium, or large. The default if no size is specified will be NASA's Full Resolution photo url.
Example of size query: /api/perseverance/images?per_page=1&size=large -> returns a single string url link for a large image taken by perseverance rover. 

Possible Queries for every rover endpoint
| Page                             | Per Page                  | Camera                                                                                           |
| -------------------------------- | ------------------------- | ------------------------------------------------------------------------------------------------ |
| integer                          | integer                   | string                                                                                           |
| example: ?page=2                 | example: \n ?per_page=25  | ex: ?camera=FHAZ_RIGHT_A                                                                         |
| *Note must be used with per_page |                           | querying multiple cameras can be done by separating each camera with the pipe character: & #124; |

Cameras
TODO ADD in camera filtering for each rover

Contributing
If you would like to contribute to this Mars Rover API, feel free to create a pull request.

Fork this repository,
Create your feature branch,
Commit your changes,
Push to the branch,
Create a new Pull Request
