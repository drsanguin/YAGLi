Feature: Check if a undirected graph contains one ore more vertex/vertices

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

Scenario: Check that a undirected graph contains the expected IEnumerable of vertices
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
	When I check that the graph contains the following IEnumerable of vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	Then I get the answer true

Scenario: Check that a undirected graph contains the expected array of vertices
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
	When I check that the graph contains the following array of vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	Then I get the answer true

Scenario: Check that a undirected graph does not contains the expected IEnumerable of vertices
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
	When I check that the graph contains the following IEnumerable of vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	| v5   |
	Then I get the answer false

Scenario: Check that a undirected graph does not contains the expected array of vertices
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
	When I check that the graph contains the following array of vertices
	| Name |
	| v0   |
	| v3   |
	| v4   |
	| v5   |
	Then I get the answer false