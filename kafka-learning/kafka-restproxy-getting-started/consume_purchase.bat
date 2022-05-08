curl -X POST -H "Content-Type: application/vnd.kafka.v2+json" --data "{\"name\": \"ci1\", \"format\": \"json\", \"auto.offset.reset\": \"earliest\"}" http://localhost:8082/consumers/cg1

curl -X POST -H "Content-Type: application/vnd.kafka.v2+json" --data "{\"topics\":[\"purchases\"]}" http://localhost:8082/consumers/cg1/instances/ci1/subscription

curl -X GET -H "Accept: application/vnd.kafka.json.v2+json" http://localhost:8082/consumers/cg1/instances/ci1/records 

curl -X GET -H "Accept: application/vnd.kafka.json.v2+json" http://localhost:8082/consumers/cg1/instances/ci1/records 