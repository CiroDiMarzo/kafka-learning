curl -X POST -H "Content-Type: application/vnd.kafka.json.v2+json" -H "Accept: application/vnd.kafka.v2+json" --data "{\"records\":[{\"key\":\"jsmith\",\"value\":\"alarm clock\"},{\"key\":\"htanaka\",\"value\":\"batteries\"}]}" "http://localhost:8082/topics/purchases"

