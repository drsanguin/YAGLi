Feature: Instantiate a undirected graph

Scenario: Create a undirected graph who disallow loops and parallel edges
	Given the property disallow loops 
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |
	| v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And he should contains the edges
	| End1 | End2 |
	| v0   | v1   |

Scenario: Create a undirected graph who disallow loops and allow parallel edges
	Given the property disallow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |
	| v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And he should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |

Scenario: Create a undirected graph who allow loops and disallow parallel edges
	Given the property allow loops
	And the property disallow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |
	| v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And he should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v1   |

Scenario: Create a undirected graph who allow loops and parallel edges
	Given the property allow loops
	And the property allow parallel edges
	And the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |
	| v1   | v1   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	And he should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v0   | v1   |
	| v1   | v1   |

Scenario: Create a UndirectedGraph by passing to the constructor edges who contains vertices who are not passed in the constructor
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
	| v5   | v6   |
	When I create a new undirected graph with them
	Then he should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And he should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v4   | v4   |