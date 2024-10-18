
# GFT Grosvenor Developer Code Challenge - .NET Developer

This project is a challenge to show the developer's .NET skills and also architecture skills:


## Badges

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](https://choosealicense.com/licenses/mit/)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Prometheus](https://img.shields.io/badge/Prometheus-E6522C?style=for-the-badge&logo=Prometheus&logoColor=white)
![Grafana](https://img.shields.io/badge/grafana-%23F46800.svg?style=for-the-badge&logo=grafana&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

## This project uses

- ASP NET WebAPI
- Serilog
- Grafana
- Prometheus

## Cloning and starting the project with Docker Compose
Clone the project with SSH
```bash
  git clone git@github.com:miguelpombodev/gft_grosvenor_developer_code_challenge.git GFTGrovelorDeveloperChallenge
```
or clone with HTTP

```bash
  git clone https://github.com/miguelpombodev/gft_grosvenor_developer_code_challenge.git GFTGrovelorDeveloperChallenge
```

Go to the directory

```bash
  cd GFTGrovelorDeveloperChallenge
```

If you choose to use Docker Compose, now just run:
```bash
  docker-compose up
```
So all the services will be created as needed, however the ASPNETCORE_ENVIRONMENT __env var__ is set to **"Production"** value

### Using Grafana and Prometheus
To access the Grafana tool and Prometheus, you can follow the following steps:

You also can see metrics from the API in the **/metrics** endpoint:

API Metrics: http://localhost:8080/metrics


To check if Prometheus container is connected to the API, go at:
http://localhost:9090/targets

Expected result:
![alt text](https://miro.medium.com/v2/resize:fit:700/1*GxVKAlyZ9wDa6F-8dRklDg.png)

To use Grafana, you can go at: http://localhost:3000/

Log in with username and password **‘admin’**, after that, and add a new data source connection:
![alt text](https://miro.medium.com/v2/resize:fit:700/1*D3akUBo20vx8mCfNFzT2WA.png)

Click on **‘Add new Data Source’** in the **‘Connection’** set the Prometheus URL: “http://prometheus:9090”
![alt text](https://miro.medium.com/v2/resize:fit:700/1*8OusJb9CFXA8qdoZTshNYQ.png)

Go to **Dashboards** > **Create new Dash board** > + **Add Visualization**

Then click on **Code** and **add**: “sum by(code) (http_request_duration_seconds_bucket)”
![alt text](https://miro.medium.com/v2/resize:fit:700/1*mqLjP-ZZwJNnuL9eaG5pFA.png)


## License
[MIT](https://choosealicense.com/licenses/mit/)