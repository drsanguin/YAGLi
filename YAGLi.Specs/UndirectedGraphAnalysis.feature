Feature: UndirectedGraphAnalysis

Scenario: Get the adjacent edges of an edge located into a undirected graph who allow loops and parallel edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	When I create a new undirected graph with them
	Then the adjacent edges of the edge "e3" should be
	| Name |
	| e1   |
	| e2   |
	| e4   |

Scenario: Get the adjacent edges of an edge not located into a undirected graph who allow loops and parallel edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v3   | v4   |
	When I create a new undirected graph with them
	Then the adjacent edges of the edge with the ends "v0" and "v4" should be empty

Scenario: Get the adjacent edges of an edge not located into a undirected graph who allow loops and disallow parallel edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	When I create a new undirected graph with them
	Then the adjacent edges of the edge with the ends "v0" and "v4" should be empty

Scenario: Get the adjacent edges of an edge equal to an edge located into a undirected graph who allow loops and disallow parallel edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	When I create a new undirected graph with them
	Then the adjacent edges of the edge with the ends "v3" and "v4" should be
	| Name |
	| e1   |
	| e2   |

Scenario: Get the adjacent vertices of a vertex contained in a UndirectedGraph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the adjacent vertices of the vertex "v1" should be
	| Name |
	| v0   |
	| v4   |

Scenario: Get the adjacent vertices of a vertex not contained in a UndirectedGraph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the adjacent vertices of the vertex "v5" should be empty

Scenario: Get the degree of a vertex not contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the degree of the vertex "v5" should be -1

Scenario: Get the degree of a vertex contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the degree of the vertex "v4" should be 5

Scenario: Get the in degree of a vertex not contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the in degree of the vertex "v5" should be -1

Scenario: Get the in degree of a vertex contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the in degree of the vertex "v4" should be 5

Scenario: Get the out degree of a vertex not contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the out degree of the vertex "v5" should be -1

Scenario: Get the out degree of a vertex contained in the graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the out degree of the vertex "v4" should be 5

Scenario: Get the incident edges of a vertex contained in a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the incident edges of the vertex "v4" should be
	| Name |
	| e1   |
	| e2   |
	| e3   |
	| e4   |

Scenario: Get the incident edges of a vertex not contained in a undirected graph
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the incident edges of the vertex "v5" should be empty

Scenario: Get the incident vertices of a edge contained in a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the incident vertices of the edge "e1" should be
	| Name |
	| v1   |
	| v4   |

Scenario: Get the incident vertices of a edge not contained in a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the incident vertices of the edge with the ends "v0" and "v4" should be empty

Scenario: Get the incident vertices of a loop edge contained in a undirected graph
Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And the edges
	| Name | End1 | End2 |
	| e0   | v0   | v1   |
	| e1   | v1   | v4   |
	| e2   | v4   | v4   |
	| e3   | v4   | v3   |
	| e4   | v4   | v3   |
	When I create a new undirected graph with them
	Then the incident vertices of the edge "e2" should be
	| Name |
	| v4   |