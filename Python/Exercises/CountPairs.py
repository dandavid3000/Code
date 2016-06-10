#!/usr/bin/python

#A = [1, 8, -3, 0, 1, 3, -2, 4, 5]
A = [-2147483648, -2147483648]
def solution(K, A):
    contenga = {}
    for x in A:
        if x not in contenga:
            contenga[x] = 0
        contenga[x] += 1
    N = 0
    for i in contenga:
        N += contenga[i] * contenga.get(K-i, 0)
    return N

print solution(0, A)