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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge
	| End1 | End2 |
	| v4   | v3   |
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |
	| v3   | v4   |

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge with the ends "v0" and "v4"
	Then I get a empty list of edges

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge with the ends "v0" and "v4"
	Then I get a empty list of edges

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	And the undirected graph created with them
	When I retrieve the adjacent edges of the edge with the ends "v3" and "v4"
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I retrieve the adjacent vertices of the vertex "v1"
	Then I get the vertices
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I retrieve the adjacent vertices of the vertex "v5"
	Then I get a empty list of vertices

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I get the degree of the vertex "v5"
	Then I get the degree -1

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I get the degree of the vertex "v4"
	Then I get the degree 5

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
	And the undirected graph created with them
	When I retrieve the incident edges of the vertex "v4"
	Then I get the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I retrieve the incident edges of the vertex "v5"
	Then I get a empty list of edges

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I get the incident vertices of the edge
	| End1 | End2 |
	| v1   | v4   |
	Then I get the vertices
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I get the incident vertices of the edge with the ends "v0" and "v4"
	Then I get a empty list of vertices

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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I get the incident vertices of the edge
	| End1 | End2 |
	| v4   | v4   |
	Then I get the vertices
	| Name |
	| v4   |

Scenario: Check that a undirected graph contains the expected vertex
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the vertex "v0"
	Then I get the answer true

Scenario: Check that a undirected graph does not contains the expected vertex
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the vertex "v5"
	Then I get the answer false

Scenario: Check that a undirected graph contains the expected vertices
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	Then I get the answer true

Scenario: Check that a undirected graph does not contains the expected vertices
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	| v5   |
	Then I get the answer false

Scenario: Check that a undirected graph who allow parallel edges contains a edge
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edge
	| End1 | End2 |
	| v0   | v1   |
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges contains a edge with the same ends
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edge with the ends "v0" and "v1"
	Then I get the answer false

Scenario: Check that a undirected graph who disallow parallel edges contains a edge with the same ends
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edge with the ends "v0" and "v1"
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges contains edges
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that a undirected graph who allow parallel edges does not contains edges with the same ends
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer false

Scenario: Check that a undirected graph who disallow parallel edges contains edges with the same ends
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check that the graph contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v3   |
	Then I get the answer true

Scenario: Check that two vertices connected in a undirected graph are adjacent
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check if the vertices "v0" and "v1" are adjacent
	Then I get the answer true

Scenario: Check that two vertices not connected in a undirected graph are not adjacent
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check if the vertices "v0" and "v2" are adjacent
	Then I get the answer false

Scenario: Check that two edges who share a common vertex in a undirected graph are adjacent
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	Then I get the answer true

Scenario: Check that two vertices who do not share a common vertex in a undirected graph are not adjacent
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
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v4   | v3   |
	And the undirected graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v4   | v4   |
	Then I get the answer false

Scenario: Check that two vertices with one not contains in the graph but who share a common vertex are not adjacent
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
	And the undirected graph created with them
	When I check if the following edges are adjacent
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v4   |
	Then I get the answer false