\# Hone Assignment – Kubernetes Multi-Tier Application

&#x20;

\## Repository URL

https://github.com/Megha1788/NAGP-k8s

&#x20;

\---

&#x20;

\## Docker Hub URL

https://hub.docker.com/r/meghaagarwal2324/nagp-api

&#x20;

Image:

meghaagarwal2324/nagp-api:v2

&#x20;

\---

&#x20;

\## Service API URL

&#x20;

Products API:

http://34.24.6.108/products

&#x20;

UI:

http://34.24.6.108/ui

&#x20;

\---

&#x20;

\# Requirement Understanding

&#x20;

Build a multi-tier application deployed on Kubernetes with:

&#x20;

\- Service/API Tier

\- Database Tier

\- External accessibility

\- Configuration management

\- Secrets management

\- Persistence

\- Scaling

\- Self-healing

\- Cost optimization

&#x20;

\---

&#x20;

\# Assumptions

&#x20;

\- Kubernetes cluster is available.

\- Docker Hub is available for image storage.

\- PostgreSQL is used as database.

\- .NET 8 is used for API implementation.

\- Ingress is available for external access.

&#x20;

\---

&#x20;

\# Solution Overview

&#x20;

Architecture:

&#x20;

```

Internet

&#x20;  ↓

Ingress

&#x20;  ↓

Service API (Deployment)

&#x20;  ↓

PostgreSQL (StatefulSet)

&#x20;  ↓

Persistent Volume

```

&#x20;

Components:

&#x20;

\- Ingress

\- Service API Deployment

\- PostgreSQL StatefulSet

\- ConfigMap

\- Secret

\- HPA

\- Persistent Volume

&#x20;

\---

&#x20;

\# Implementation Details

&#x20;

\## Service API Tier

&#x20;

Implemented using:

&#x20;

\- .NET 8 Web API

\- Docker

\- Kubernetes Deployment

&#x20;

Features:

&#x20;

\- API endpoint exposed externally

\- Database connectivity

\- Connection pooling

\- Configuration via ConfigMap

\- Secret usage

\- Rolling updates

\- Self-healing

\- Horizontal Pod Autoscaling

&#x20;

Endpoints:

&#x20;

\### Products

&#x20;

```

GET /products

```

&#x20;

Returns products from PostgreSQL.

&#x20;

\### UI

&#x20;

```

GET /ui

```

&#x20;

Displays products in HTML UI.

&#x20;

\---

&#x20;

\## Database Tier

&#x20;

Implemented using:

&#x20;

\- PostgreSQL

\- StatefulSet

\- Persistent Volume Claim

&#x20;

Features:

&#x20;

\- Persistent storage

\- Internal ClusterIP access only

\- Automatic recovery after pod deletion

&#x20;

Sample data:

&#x20;

| ID | Name | Price |

|----|------|------|

| 1 | Laptop | 1000 |

| 2 | Phone | 500 |

| 3 | Mouse | 50 |

| 4 | Monitor | 250 |

| 5 | Keyboard | 80 |

&#x20;

\---

&#x20;

\# Kubernetes Resources

&#x20;

Contained in:

&#x20;

```

k8s/

```

&#x20;

Files:

&#x20;

```

namespace.yaml

configmap.yaml

secret.yaml

&#x20;

api-deployment.yaml

api-service.yaml

&#x20;

db-statefulset.yaml

db-service.yaml

&#x20;

ingress.yaml

hpa.yaml

```

&#x20;

\---

&#x20;

\# Deployment

&#x20;

Deploy all resources:

&#x20;

```bash

kubectl apply -f k8s/

```

&#x20;

Verify:

&#x20;

```bash

kubectl get all -n nagp

```

&#x20;

\---

&#x20;

\# Demonstrated Requirements

&#x20;

\## Service API

&#x20;

✅ Exposed endpoint  

✅ Database access  

✅ ConfigMap  

✅ Secrets  

✅ Rolling updates  

✅ Self-healing  

✅ HPA  

&#x20;

\---

&#x20;

\## Database

&#x20;

✅ 5 records inserted  

✅ Persistent storage  

✅ Cluster internal access  

✅ Recovery after pod deletion  

&#x20;

\---

&#x20;

\## Kubernetes Requirements

&#x20;

| Feature | Service API | Database |

|----------|------------|----------|

| External Access | Yes | No |

| Number of Pods | 4 | 1 |

| Rolling Updates | Yes | No |

| Persistent Storage | No | Yes |

| ConfigMap | Yes | Optional |

| Secrets | Yes | Yes |

&#x20;

\---

&#x20;

\# FinOps Considerations

&#x20;

Resource Optimization:

&#x20;

Service API:

&#x20;

CPU Request:

50m

&#x20;

CPU Limit:

150m

&#x20;

Memory Request:

64Mi

&#x20;

Memory Limit:

128Mi

&#x20;

Optimizations:

&#x20;

1\. HPA used instead of fixed scaling

2\. CPU and memory right-sized

3\. Database isolated using ClusterIP

&#x20;

\---

&#x20;

\# Demonstration

&#x20;

Included in submission:

&#x20;

\- Kubernetes deployment

\- API execution

\- Self healing

\- Persistence

\- Rolling updates

\- HPA scaling

\- FinOps validation

&#x20;

\---

&#x20;

\# Submission Contents

&#x20;

\- Source Code

\- Kubernetes YAML files

\- Dockerfile

\- README

\- Demo Video

