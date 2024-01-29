-- CreateTable
CREATE TABLE "AccountsMetric" (
    "id" VARCHAR(40) NOT NULL,
    "userCount" INTEGER NOT NULL,
    "dayCount" INTEGER NOT NULL,

    CONSTRAINT "AccountsMetric_pkey" PRIMARY KEY ("id")
);
