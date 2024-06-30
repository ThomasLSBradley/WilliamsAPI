The Where and GroupBy parameters are both optional.
Field names are case sensitive (use the field names swagger displays in PascalCase)

The GroupBy 'overloads' parameter is not implemented.

GroupBy currently mutates the internal caches.
Datetime comprison/aggregation does not seem to work as intended.

Recommended payloads to try:

/circuit

{
  "whereClause": {
    "field": "Altitude",
    "operator": 1,
    "value": "1000"
  },
  "groupByClause": null
}

/lapTime

{
  "whereClause": null,
  "groupByClause": {
    "field": "Driver",
    "aggregationMethod": 1,
    "overloads": {}
  }
}