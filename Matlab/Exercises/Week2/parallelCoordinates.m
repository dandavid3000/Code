
clc;
clear all;
load bank;
labs = {'Chieu Dai','Chieu Rong Trai','Chieu Rong Phai','Chieu Rong Le Tren','Chieu Rong Le Duoi','Duong Cheo Hinh Trong'};
for i = 1 : 100
    s(i,1) = {'forge'};
end
for i = 101:200
    s(i,1) = {'genuine'};
end
meas = [forge;genuine];
parallelcoords(meas,'group',s,'labels',labs,'quantile',.25);