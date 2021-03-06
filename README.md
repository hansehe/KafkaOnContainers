﻿# KafkaOnContainers
Spike to get to know Kafka

## Get Started
1. Install [Docker](https://www.docker.com/)
2. Install [Python](https://www.python.org/) and [pip](https://pypi.org/project/pip/)
    - Windows:  https://matthewhorne.me/how-to-install-python-and-pip-on-windows-10/
    - Ubuntu: Python is installed by default
        - Install pip: sudo apt-get install python-pip
3. Install python dependencies:
    - pip install -r requirements.txt
4. See available commands:
    - python DockerBuild.py help

## Build & Run
1. Start domain development by deploying service dependencies:
    - python DockerBuild.py start-dev
2. Build solution as container images:
    - python DockerBuild.py build
3. Test solution in containers:
    - python DockerBuild.py test
4. Run solution in containers:
    - python DockerBuild.py run
5. Open solution and continue development:
    - [KafkaOnContainers](src/KafkaOnContainers)
5. Stop development when you feel like it:
    - python DockerBuild.py stop-dev

## Additional Info

## Buildsystem
- [DockerBuildSystem](https://github.com/DIPSAS/DockerBuildSystem)
- [SwarmManagement](https://github.com/DIPSAS/SwarmManagement)
