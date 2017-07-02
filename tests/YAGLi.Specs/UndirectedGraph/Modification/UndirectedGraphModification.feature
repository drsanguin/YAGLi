Feature: UndirectedGraphModification

Scenario: Add a loop to a undirected graph who disallow loops
	Given the property disallow loops
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edges
    | End1 | End2 |
	| v0   | v0   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a parallel edge to a undirected graph who disallow parallel edges
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
	| v4   | v3   |
	And the undirected graph created with them
	When I add the edges
    | End1 | End2 |
	| v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |

Scenario: Add a loop to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edges
    | End1 | End2 |
	| v0   | v0   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v0   |

Scenario: Add a parallel edge to a undirected graph
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
	| v4   | v3   |
	And the undirected graph created with them
	When I add the edges
    | End1 | End2 |
	| v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a edge to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edge
    | End1 | End2 |
	| v0   | v2   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v2   |

Scenario: Add edges to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edges
	| End1 | End2 |
	| v0   | v2   |
	| v1   | v2   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v0   | v2   |
	| v1   | v2   |

Scenario: Add a edge with vertices who are not already contained in a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edge
    | End1 | End2 |
	| v5   | v6   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add a vertex to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the vertex "v5"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add vertices to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the vertices
    | Name |
	| v5   |
	| v6   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	And this new undirected graph should contains the edges
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Add edge and vertices to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the following edge with their vertices
	| End1 | End2 |
	| v5   | v6   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v5   | v6   |

Scenario: Add edges and vertices to a undirected graph
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
	| v4   | v3   |
	| v3   | v4   |
	And the undirected graph created with them
	When I add the edges and vertices
    | End1 | End2 |
	| v5   | v6   |
	| v0   | v7   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	| v5   |
	| v6   |
	| v7   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v3   |
	| v3   | v4   |
	| v5   | v6   |
	| v0   | v7   |

Scenario: Remove an edge from a undirected graph
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
	When I remove the edge
    | End1 | End2 |
	| v0   | v1   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Remove a parallel edge from a undirected graph
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
	When I remove the edge
    | End1 | End2 |
	| v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |

Scenario: Remove an edge and her vertices from a undirected graph
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
	When I remove the edge and her vertices
    | End1 | End2 |
	| v0   | v1   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Remove a parallel edge her vertices from a undirected graph
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
	When I remove the edge and her vertices
    | End1 | End2 |
	| v3   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	| v4   | v4   |
	| v4   | v3   |

Scenario: Remove edges from a undirected graph
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
	When I remove the edges
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Remove edges and their vertices from a undirected graph
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
	When I remove the edges and their vertices
    | End1 | End2 |
	| v0   | v1   |
	| v1   | v4   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |

Scenario: Remove a vertex from a undirected graph
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
	When I remove the vertex "v4"
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v0   |
	| v1   |
	| v2   |
	| v3   |
	And this new undirected graph should contains the edges
    | End1 | End2 |
    | v0   | v1   |

Scenario: Remove vertices from a undirected graph
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
	When I remove the vertices
	| Name |
	| v0   |
	| v1   |
	Then I should get a new undirected graph
	And this new undirected graph should contains the vertices
	| Name |
	| v2   |
	| v3   |
	| v4   |
	And this new undirected graph should contains the edges
	| End1 | End2 |
	| v4   | v4   |
	| v4   | v3   |
	| v3   | v4   |