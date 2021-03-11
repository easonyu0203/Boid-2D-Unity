# Code Adventure: Boids

Start Time: Feb 28, 2021
Status: In Progress
Type: Unity

## Introduction

Instead of controlling the interactions of an entire flock, however, the Boids simulation only specifies the behavior of each individual bird. With only a few simple rules, the program manages to generate a result that is complex and realistic enough to be used as a framework for computer graphics applications such as computer generated behavioral animation in motion picture films.

### Thee Boids Algorithm rules

- Separation

    Each bird attempts to maintain a reasonable amount of distance between itself and any nearby birds, to prevent overcrowding.

- Alignment

    Birds try to change their position so that it corresponds with the average alignment of other nearby birds.

- Cohesion

    Every bird attempts to move towards the average position of other nearby birds.

## GamePlay

Although this is made by Unity is isn't really a game but an algorithm visualization. You can twist the weight of each rule apply to fish and the fish count.

## Inspiration

- The first video I watch

    [Coding Adventure: Boids](https://www.youtube.com/watch?v=bqtqltqcQhw)

- The pseudocode I read online

    [Boids Pseudocode](http://www.vergenet.net/~conrad/boids/pseudocode.html)
