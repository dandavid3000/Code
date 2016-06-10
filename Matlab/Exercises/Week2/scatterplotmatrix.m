
clc;
clear all;
load bank;
%forge
N = size(forge,1);
MUY = zeros(1,6);
P_forge = 1/3;
P_genuine = 2/3;
[p1,p2,p3,p4,p5,p6] = learn(forge, genuine , P_forge , P_genuine);

data_f = mvnrnd(MUY,p3,N);
data_g = mvnrnd(MUY,p6,N);

% plot
plotmatrix(data_f);
figure
plotmatrix(data_g);